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
	public class AgendaController : Controller
	{
		private readonly Contexto _context;

		public AgendaController(Contexto context)
		{
			_context = context;
		}

		// GET: Agenda
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				ViewData["Alunos"] = await _context.Aluno.Where(x => x.Status == 1).ToListAsync();
				ViewData["Agendamentos"] = await _context.Agenda.ToListAsync();
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// GET: Agenda/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var agenda = await _context.Agenda
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (agenda == null)
			{
				return NotFound();
			}

			return View(agenda);
		}

		// GET: Agenda/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Agenda/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Agenda agenda)
		{
			agenda.UsuarioCodigo = HttpContext.Session.GetInt32("usuarioCodigo");
			_context.Add(agenda);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Agenda/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var agenda = await _context.Agenda.FindAsync(id);
			if (agenda == null)
			{
				return NotFound();
			}
			return View(agenda);
		}

		// POST: Agenda/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Codigo")] Agenda agenda)
		{
			if (id != agenda.Codigo)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(agenda);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AgendaExists(agenda.Codigo))
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
			return View(agenda);
		}

		// GET: Agenda/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var agenda = await _context.Agenda
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (agenda == null)
			{
				return NotFound();
			}

			return View(agenda);
		}

		// POST: Agenda/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var agenda = await _context.Agenda.FindAsync(id);
			_context.Agenda.Remove(agenda);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AgendaExists(int id)
		{
			return _context.Agenda.Any(e => e.Codigo == id);
		}

		public async Task<JsonResult> Dados()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");

				var dados = await (from ag in _context.Agenda
								   join al in _context.Aluno on ag.AlunoCodigo equals al.Codigo
								   join usu in _context.Usuario on ag.UsuarioCodigo equals usu.Codigo
								   select new
								   {
									   id = ag.Codigo,
									   start = ag.DtAgendamento,
									   especialista = usu.Nome,
									   especialistaCodigo = usu.Codigo,
									   title = al.Nome,
									   textColor = "#fff",
									   borderColor = usu.Codigo == HttpContext.Session.GetInt32("usuarioCodigo") ? "#4680ff" : "#93BE52",
									   backgroundColor = usu.Codigo == HttpContext.Session.GetInt32("usuarioCodigo") ? "#4680ff" : "#93BE52"
								   }).ToListAsync();
				

				return Json(dados);
			}
			else
			{
				return Json(null);
			}
		}
			
	}
}
