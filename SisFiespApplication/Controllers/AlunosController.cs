using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisFiespApplication.Models;

namespace SisFiespApplication.Controllers
{
	public class AlunosController : Controller
	{
		private readonly Contexto _context;

		public AlunosController(Contexto context)
		{
			_context = context;
		}

		// GET: Alunos
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{

				ViewData["Usuario"] = HttpContext.Session.GetString("nome");

				return View(await (from e in _context.Aluno
								   join u in _context.Escola
								   on e.EscolaCodigo
								   equals u.Codigo
								   join m in _context.Modalidade
								   on e.ModalidadeCodigo
								   equals m.Codigo into m1
								   from r in m1.DefaultIfEmpty()
								   select new Aluno
								   {
									   Codigo = e.Codigo,
									   Nome = e.Nome,
									   EscolaNome = u.Nome,
									   Turno = e.Turno,
									   DtNascimento = e.DtNascimento,
									   ModalidadeNome = r.Nome
								   }).ToListAsync());
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// GET: Alunos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var aluno = await _context.Aluno
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// GET: Alunos/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Escolas"] = _context.Escola.ToList();
				ViewData["Modalidades"] = _context.Modalidade.ToList();
				ViewData["Diagnosticos"] = _context.Diagnostico.ToList();
				ViewData["ApoioEscolar"] = _context.ApoioEscolar.ToList();
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// POST: Alunos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Aluno aluno)
		{
			if (ModelState.IsValid)
			{
				aluno.Status = 1;
				aluno.DtCadastro = Convert.ToDateTime(DateTime.Today.ToString("d"));
				_context.Add(aluno);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(aluno);
		}

		// GET: Alunos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null && HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Escolas"] = _context.Escola.ToList();
				ViewData["Modalidades"] = _context.Modalidade.ToList();
				ViewData["Diagnosticos"] = _context.Diagnostico.ToList();
				ViewData["ApoioEscolar"] = _context.ApoioEscolar.ToList();

				var aluno = await _context.Aluno.FindAsync(id);

				StringWriter myWriter = new StringWriter();
				HttpUtility.HtmlDecode(aluno.Observacao, myWriter);
				aluno.Observacao = myWriter.ToString();

				if (aluno == null)
				{
					return NotFound();
				}
				return View(aluno);
			}
			else
			{
				return NotFound();
			}

		}

		// POST: Alunos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]

		public async Task<IActionResult> Edit(Aluno aluno)
		{
			try
			{
				_context.Update(aluno);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AlunoExists(aluno.Codigo))
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

		// GET: Alunos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var aluno = await _context.Aluno
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// POST: Alunos/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var aluno = await _context.Aluno.FindAsync(id);
			_context.Aluno.Remove(aluno);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AlunoExists(int id)
		{
			return _context.Aluno.Any(e => e.Codigo == id);
		}
	}
}
