using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisFiespApplication.Models;

namespace SisFiespApplication.Controllers
{
	public class AvaliacoesController : Controller
	{
		private readonly Contexto _context;

		public AvaliacoesController(Contexto context)
		{
			_context = context;
		}

		// GET: Avaliacoes
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{

				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				return View(await (from av in _context.Avaliacao
								   join al in _context.Aluno
								   on av.AlunoCodigo
								   equals al.Codigo
								   join us in _context.Usuario
								   on av.UsuarioCodigo
								   equals us.Codigo
								   join es in _context.Escola
								   on al.EscolaCodigo
								   equals es.Codigo
								   select new Avaliacao
								   {
									   Codigo = av.Codigo,
									   AlunoNome = al.Nome,
									   EspecialistaNome = us.Nome,
									   EscolaNome = es.Nome,
									   DtCadastro = av.DtCadastro,
									   Status = av.Status
								   }).OrderByDescending(x => x.Codigo).ToListAsync());
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// GET: Avaliacoes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var avaliacao = await _context.Avaliacao
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (avaliacao == null)
			{
				return NotFound();
			}

			return View(avaliacao);
		}

		// GET: Avaliacoes/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Usuarios"] = _context.Usuario.ToList().Where(x => x.Funcao == 1);
				ViewData["Alunos"] = _context.Aluno.ToList().Where(x => x.Status == 1);
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// POST: Avaliacoes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Avaliacao avaliacao)
		{
			if (ModelState.IsValid)
			{
				if (HttpContext.Session.GetString("userName") != null)
				{
					ViewData["Usuario"] = HttpContext.Session.GetString("nome");
					avaliacao.DtCadastro = DateTime.Today.ToString("d");
					avaliacao.Status = 1;
					_context.Add(avaliacao);
					await _context.SaveChangesAsync();
					ViewData["codigoAvaliacao"] = avaliacao.Codigo;
					return RedirectToAction(nameof(PartialAvaliacao), new { id = avaliacao.Codigo });
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}

			}
			return View(avaliacao);
		}

		[HttpPost]
		public async Task<IActionResult> CreateDetalhe(AvaliacaoDetalhe avaliacaoDetalhe)
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				avaliacaoDetalhe.DtCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
				avaliacaoDetalhe.TpAvaliacaoDetalhe = 1;
				if (avaliacaoDetalhe.Codigo == 0)
				{
					_context.Add(avaliacaoDetalhe);
				}
				else
				{
					_context.Update(avaliacaoDetalhe);
				}
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(PartialAvaliacao), new { id = avaliacaoDetalhe.AvaliacaoCodigo });
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}

		}

		// GET: Avaliacoes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Usuarios"] = _context.Usuario.ToList().Where(x => x.Funcao == 1);
				ViewData["Alunos"] = _context.Aluno.ToList().Where(x => x.Status == 1);
				ViewData["Aluno"] = (await (from al in _context.Aluno
											join es in _context.Escola on al.EscolaCodigo equals es.Codigo
											join mo in _context.Modalidade on al.ModalidadeCodigo equals mo.Codigo into m2
											from mod in m2.DefaultIfEmpty()
											join di in _context.Diagnostico on al.DiagnosticoCodigo equals di.Codigo into d1
											from dia in d1.DefaultIfEmpty()
											join av in _context.Avaliacao on al.Codigo equals av.AlunoCodigo into m1
											from r in m1.DefaultIfEmpty()
											join dr in _context.Usuario.Where(x => x.Funcao == 3) on es.UsuarioCodigo equals dr.Codigo into dr1
											from dir in dr1.DefaultIfEmpty()
											join usu in _context.Usuario.Where(x => x.Funcao == 1) on r.UsuarioCodigo equals usu.Codigo
											where r.Codigo == id
											select new Aluno
											{
												Codigo = al.Codigo,
												Nome = al.Nome,
												DtNascimento = al.DtNascimento,
												ModalidadeAluno = mod.Nome,
												DiagnoscoAluno = dia.Nome,
												NomeMae = al.NomeMae,
												NomePai = al.NomePai,
												Turno = al.Turno,
												Observacao = al.Observacao,
												EscolaNome = es.Nome,
												NueEscolaAluno = es.NUE,
												TelefoneEscolaAluno = es.Telefone,
												Telefone2EscolaAluno = es.Telefone2,
												BairroEscolaAluno = es.Bairro,
												CidadeEscolaAluno = es.Cidade,
												DiretorEscolaAluno = dir.Nome,
												CP1EscolaAluno = es.CP1,
												CP2EscolaAluno = es.CP2,
												EspecialistaAluno = usu.Nome
											}).FirstOrDefaultAsync());


				var avaliacao = await _context.Avaliacao.FindAsync(id);
				if (avaliacao == null)
				{
					return NotFound();
				}
				return View(avaliacao);
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// POST: Avaliacoes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]

		public async Task<IActionResult> Edit(Avaliacao avaliacao)
		{

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(avaliacao);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AvaliacaoExists(avaliacao.Codigo))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(avaliacao);
		}

		public async Task<JsonResult> DetalheAluno(Avaliacao avaliacao)
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");

				var dadosAluno = (await (from al in _context.Aluno
										 join es in _context.Escola on al.EscolaCodigo equals es.Codigo
										 join mo in _context.Modalidade on al.ModalidadeCodigo equals mo.Codigo into m2
										 from mod in m2.DefaultIfEmpty()
										 join di in _context.Diagnostico on al.DiagnosticoCodigo equals di.Codigo into d1
										 from dia in d1.DefaultIfEmpty()
										 join av in _context.Avaliacao on al.Codigo equals av.AlunoCodigo into m1
										 from r in m1.DefaultIfEmpty()
										 join dr in _context.Usuario.Where(x => x.Funcao == 3) on es.UsuarioCodigo equals dr.Codigo into dr1
										 from dir in dr1.DefaultIfEmpty()
										 where al.Codigo == avaliacao.AlunoCodigo
										 select new
										 {
											 nomeAluno = al.Nome,
											 dataNascimentoAluno = al.DtNascimento,
											 modalidadeAluno = mod.Nome,
											 diagnoscoAluno = dia.Nome,
											 nomeMae = al.NomeMae,
											 nomePai = al.NomePai,
											 turnoAluno = al.Turno,
											 observacaoAluno = al.Observacao,
											 nomeEscola = es.Nome,
											 nueEscola = es.NUE,
											 telefoneEscola = es.Telefone,
											 telefone2Escola = es.Telefone2,
											 bairroEscola = es.Bairro,
											 cidadeEscola = es.Cidade,
											 diretorEscola = dir.Nome,
											 cp1Escola = es.CP1,
											 cp2Escola = es.CP2,

										 }).FirstOrDefaultAsync());

				return Json(dadosAluno);
			}
			else
			{
				return Json(null);
			}
		}

		// GET: Avaliacoes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var avaliacao = await _context.Avaliacao
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (avaliacao == null)
			{
				return NotFound();
			}

			return View(avaliacao);
		}

		public async Task<IActionResult> PartialAvaliacao(int? id)
		{
			ViewData["ListaAvaliacaoDetalhe"] = await (from avd in _context.AvaliacaoDetalhe
													   join av in _context.Avaliacao.Where(x => x.Codigo == id)
													   on avd.AvaliacaoCodigo
													   equals av.Codigo
													   join us in _context.Usuario
													   on av.UsuarioCodigo
													   equals us.Codigo
													   select new AvaliacaoDetalhe
													   {
														   Codigo = avd.Codigo,
														   EspecialistaNome = us.Nome,
														   DtCadastro = avd.DtCadastro,
														   Procedimento = avd.Procedimento.Substring(0, 20),
														   TpAvaliacaoDetalhe = avd.TpAvaliacaoDetalhe,
														   NomeArquivo = avd.NomeArquivo

													   }).OrderByDescending(x => x.Codigo).ToListAsync();

			ViewData["codigoAvaliacao"] = id;
			return PartialView("_partialAvaliacao");
		}

		public async Task<IActionResult> PartialDetalheAvaliacao(int? id)
		{
			var avaliacaoDetalhe = await (from avd in _context.AvaliacaoDetalhe.Where(x => x.Codigo == id)
										  join av in _context.Avaliacao
										  on avd.AvaliacaoCodigo
										  equals av.Codigo
										  join al in _context.Aluno
										  on av.AlunoCodigo equals al.Codigo
										  join us in _context.Usuario
										  on av.UsuarioCodigo
										  equals us.Codigo
										  select new AvaliacaoDetalhe
										  {
											  Codigo = avd.Codigo,
											  EspecialistaNome = us.Nome,
											  DtCadastro = avd.DtCadastro,
											  Procedimento = avd.Procedimento.Substring(0, 20),
											  TpAvaliacaoDetalhe = avd.TpAvaliacaoDetalhe,
											  Conduta = avd.Conduta,
											  Envolvidos = avd.Envolvidos,
											  DescAcao = avd.DescAcao,
											  NomeAluno = al.Nome

										  }).OrderBy(x => x.Codigo).ToListAsync();
			if (avaliacaoDetalhe.Count > 0)
			{
				HttpContext.Session.SetString("avaliacaoDetalheCodigo", avaliacaoDetalhe[0].Codigo.ToString());
			}			

			ViewData["codigoAvaliacao"] = id;
			ViewData["ListaDetalhe"] = avaliacaoDetalhe;
			return PartialView("_partialDetalhe");
		}

		public async Task<IActionResult> PartialAnexos(int? id)
		{

			List<Anexo> ObjFiles = new List<Anexo>();

			if (id != 0)
			{
				HttpContext.Session.SetString("avaliacaoDetalheCodigo", id.ToString());

				string filename = "wwwroot\\tmp\\" + id + "\\";
				var path = Path.Combine(Directory.GetCurrentDirectory(), filename);

				foreach (string strfile in Directory.GetFiles(path))
				{
					FileInfo fi = new FileInfo(strfile);
					Anexo obj = new Anexo();
					obj.File = fi.Name;
					obj.Size = fi.Length;
					obj.CodigoAvaliacaoDetalhe = (int)id;
					obj.Type = GetFileTypeByExtension(fi.Extension);
					ObjFiles.Add(obj);
				}


				var avaliacaoDetalhe_ = await _context.AvaliacaoDetalhe.Where(x => x.Codigo > 1).ToListAsync();

			}
			
			ViewData["ObjFiles"] = ObjFiles;

			return PartialView("_partialAnexo");
		}

		private string GetFileTypeByExtension(string fileExtension)
		{
			switch (fileExtension.ToLower())
			{
				case ".docx":
				case ".doc":
					return "Microsoft Word Document";
				case ".xlsx":
				case ".xls":
					return "Microsoft Excel Document";
				case ".txt":
					return "Text Document";
				case ".jpg":
				case ".png":
					return "Image";
				default:
					return "Unknown";
			}
		}

		// POST: Avaliacoes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var avaliacao = await _context.Avaliacao.FindAsync(id);
			_context.Avaliacao.Remove(avaliacao);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AvaliacaoExists(int id)
		{
			return _context.Avaliacao.Any(e => e.Codigo == id);
		}

		[HttpPost]
		[RequestFormLimits(MultipartBodyLengthLimit = 1209715200)]
		[RequestSizeLimit(1209715200)]
		public async Task<ActionResult> File(IFormFile file)
		{
			string avaliacaoDetalheCodigo = HttpContext.Session.GetString("avaliacaoDetalheCodigo");

			var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName("../SisFiespApplication/wwwroot/tmp/" + avaliacaoDetalheCodigo + "/"));

			if (!destinationDirectory.Exists)
				destinationDirectory.Create();

			FileStream filestream = new FileStream(destinationDirectory + "/" + file.FileName, FileMode.Create, FileAccess.Write);

			using (var memoryStream = new MemoryStream())
			{
				await file.CopyToAsync(memoryStream);

				memoryStream.WriteTo(filestream);
				memoryStream.Dispose();
			}

			AvaliacaoDetalhe avaliacaoDetalhe = await _context.AvaliacaoDetalhe.FindAsync(Convert.ToInt32(avaliacaoDetalheCodigo));
			avaliacaoDetalhe.NomeArquivo = file.FileName;

			_context.Update(avaliacaoDetalhe);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(PartialAnexos), new { id = Convert.ToInt32(avaliacaoDetalheCodigo) });
		}

		[HttpPost]
		public ActionResult SetValorDetalhe(int? Codigo)
		{
			HttpContext.Session.SetString("avaliacaoDetalheCodigo", Codigo.ToString());
			return Ok();
		}

		public FileResult Download(string filename, int codigo)
		{

			string filename_ = filename;

			filename = "wwwroot\\tmp\\" + codigo + "\\" + filename;

			var path = Path.Combine(Directory.GetCurrentDirectory(), filename);

			byte[] fileBytes = System.IO.File.ReadAllBytes(path);

			return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename_);

		}

		private string GetContentType(string fileName)
		{
			string strcontentType = "application/octetstream";
			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
			if (registryKey != null && registryKey.GetValue("Content Type") != null)
				strcontentType = registryKey.GetValue("Content Type").ToString();
			return strcontentType;
		}
	}
}
