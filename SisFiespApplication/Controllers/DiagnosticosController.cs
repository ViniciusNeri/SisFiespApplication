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
	public class DiagnosticosController : Controller
	{
		private readonly Contexto _context;

		public DiagnosticosController(Contexto context)
		{
			_context = context;
		}

		// GET: Diagnosticos
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				return View(await _context.Diagnostico.ToListAsync());
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// GET: Diagnosticos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var diagnostico = await _context.Diagnostico
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (diagnostico == null)
			{
				return NotFound();
			}

			return View(diagnostico);
		}

		// GET: Diagnosticos/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// POST: Diagnosticos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Diagnostico diagnostico)
		{
			if (ModelState.IsValid)
			{
				_context.Add(diagnostico);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(diagnostico);
		}

		// GET: Diagnosticos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null && HttpContext.Session.GetString("userName") != null)
			{
				var diagnostico = await _context.Diagnostico.FindAsync(id);
				if (diagnostico == null)
				{
					return NotFound();
				}
				return View(diagnostico);
			}
			else
			{
				return NotFound();
			}
		}

		// POST: Diagnosticos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Edit(Diagnostico diagnostico)
		{

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(diagnostico);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DiagnosticoExists(diagnostico.Codigo))
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
			return View(diagnostico);
		}

		// GET: Diagnosticos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var diagnostico = await _context.Diagnostico
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (diagnostico == null)
			{
				return NotFound();
			}

			return View(diagnostico);
		}

		// POST: Diagnosticos/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var diagnostico = await _context.Diagnostico.FindAsync(id);
			_context.Diagnostico.Remove(diagnostico);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DiagnosticoExists(int id)
		{
			return _context.Diagnostico.Any(e => e.Codigo == id);
		}
	}
}
