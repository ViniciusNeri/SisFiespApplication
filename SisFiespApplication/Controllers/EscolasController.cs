using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisFiespApplication.Models;

namespace SisFiespApplication.Controllers
{
	public class EscolasController : Controller
	{
		private readonly Contexto _context;

		public EscolasController(Contexto context)
		{
			_context = context;
		}

		// GET: Escolas
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{

				ViewData["Usuario"] = HttpContext.Session.GetString("nome");

				return View(await (from e in _context.Escola
								   join u in _context.Usuario
								   on e.UsuarioCodigo
								   equals u.Codigo
								   select new Escola
								   {
									   Bairro = e.Bairro,
									   CaractSocioEcon = e.CaractSocioEcon,
									   Cidade = e.Cidade,
									   Codigo = e.Codigo,
									   CP1 = e.CP1,
									   CP2 = e.CP2,
									   DtCadastro = e.DtCadastro,
									   Email = e.Email,
									   Endereco = e.Endereco,
									   Nome = e.Nome,
									   NUE = e.NUE,
									   RecursoRegiao = e.RecursoRegiao,
									   Status = e.Status,
									   Telefone = e.Telefone,
									   Telefone2 = e.Telefone2,
									   Usuario = e.Usuario,
									   UsuarioNome = u.Nome
								   }).ToListAsync());
			}
			else
			{
				return Json(new { status = "error", message = "error creating customer" });
			}
		}

		// GET: Escolas/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var escola = await _context.Escola
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (escola == null)
			{
				return NotFound();
			}

			return View(escola);
		}

		// GET: Escolas/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Usuarios"] = _context.Usuario.ToList().Where(x => x.Funcao == 3);
				return View();
			}
			else
			{
				return Json(new { status = "error", message = "error creating customer" });
			}
		}

		// POST: Escolas/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Escola escola)
		{
			if (ModelState.IsValid)
			{
				escola.Status = 1;
				escola.DtCadastro = DateTime.Today.ToString("d");
				_context.Add(escola);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(escola);
		}

		// GET: Escolas/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{

			if (id != null && HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Usuarios"] = _context.Usuario.ToList().Where(x => x.Funcao == 3);

				var escola = await (from e in _context.Escola
									join u in _context.Usuario
									on e.UsuarioCodigo
									equals u.Codigo
									where e.Codigo == id
									select new Escola
									{
										Bairro = e.Bairro,
										CaractSocioEcon = e.CaractSocioEcon,
										Cidade = e.Cidade,
										Codigo = e.Codigo,
										CP1 = e.CP1,
										CP2 = e.CP2,
										DtCadastro = e.DtCadastro,
										Email = e.Email,
										Endereco = e.Endereco,
										Nome = e.Nome,
										NUE = e.NUE,
										RecursoRegiao = e.RecursoRegiao,
										Status = e.Status,
										Telefone = e.Telefone,
										Telefone2 = e.Telefone2,
										Usuario = e.Usuario,
										UsuarioCodigo = e.UsuarioCodigo,
										UsuarioNome = u.Nome
									}).SingleOrDefaultAsync();
				if (escola == null)
				{
					return NotFound();
				}
				return View(escola);

			}
			else
			{
				return NotFound();
			}

		}

		// POST: Escolas/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Edit(Escola escola)
		{

			if (ModelState.IsValid)
			{
				try
				{
					escola.Status = 1;
					escola.DtCadastro = DateTime.Today.ToString("d");
					_context.Update(escola);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EscolaExists(escola.Codigo))
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
			return View(escola);
		}

		// GET: Escolas/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var escola = await _context.Escola
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (escola == null)
			{
				return NotFound();
			}

			return View(escola);
		}

		// POST: Escolas/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var escola = await _context.Escola.FindAsync(id);
			_context.Escola.Remove(escola);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool EscolaExists(int id)
		{
			return _context.Escola.Any(e => e.Codigo == id);
		}
	}
}
