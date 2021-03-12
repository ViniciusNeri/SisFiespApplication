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
	public class ModalidadesController : Controller
	{
		private readonly Contexto _context;

		public ModalidadesController(Contexto context)
		{
			_context = context;
		}

		// GET: Modalidades
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				return View(await _context.Modalidade.ToListAsync());
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		// GET: Modalidades/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var modalidade = await _context.Modalidade
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (modalidade == null)
			{
				return NotFound();
			}

			return View(modalidade);
		}

		// GET: Modalidades/Create
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

		// POST: Modalidades/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(Modalidade modalidade)
		{
			if (ModelState.IsValid)
			{
				_context.Add(modalidade);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(modalidade);
		}

		// GET: Modalidades/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{

			if (id != null && HttpContext.Session.GetString("userName") != null)
			{
				var modalidade = await _context.Modalidade.FindAsync(id);
				if (modalidade == null)
				{
					return NotFound();
				}
				return View(modalidade);
			}
			else
			{
				return NotFound();
			}
		}

		// POST: Modalidades/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Edit(Modalidade modalidade)
		{

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(modalidade);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ModalidadeExists(modalidade.Codigo))
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
			return View(modalidade);
		}

		// GET: Modalidades/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var modalidade = await _context.Modalidade
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (modalidade == null)
			{
				return NotFound();
			}

			return View(modalidade);
		}

		// POST: Modalidades/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var modalidade = await _context.Modalidade.FindAsync(id);
			_context.Modalidade.Remove(modalidade);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ModalidadeExists(int id)
		{
			return _context.Modalidade.Any(e => e.Codigo == id);
		}
	}
}
