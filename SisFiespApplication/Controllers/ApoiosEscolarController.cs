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
	public class ApoiosEscolarController : Controller
	{
		private readonly Contexto _context;

		public ApoiosEscolarController(Contexto context)
		{
			_context = context;
		}

		// GET: ApoiosEscolar
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("userName") != null)
			{
				ViewData["Usuario"] = HttpContext.Session.GetString("nome");
				return View(await _context.ApoioEscolar.ToListAsync());
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}


		}

		// GET: ApoiosEscolar/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var apoioEscolar = await _context.ApoioEscolar
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (apoioEscolar == null)
			{
				return NotFound();
			}

			return View(apoioEscolar);
		}

		// GET: ApoiosEscolar/Create
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

		// POST: ApoiosEscolar/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create(ApoioEscolar apoioEscolar)
		{
			if (ModelState.IsValid)
			{
				_context.Add(apoioEscolar);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(apoioEscolar);
		}

		// GET: ApoiosEscolar/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null && HttpContext.Session.GetString("userName") != null)
			{

				var apoioEscolar = await _context.ApoioEscolar.FindAsync(id);
				if (apoioEscolar == null)
				{
					return NotFound();
				}
				return View(apoioEscolar);
			}
			else
			{
				return NotFound();
			}
		}

		// POST: ApoiosEscolar/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Edit(ApoioEscolar apoioEscolar)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(apoioEscolar);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ApoioEscolarExists(apoioEscolar.Codigo))
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
			return View(apoioEscolar);
		}

		// GET: ApoiosEscolar/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var apoioEscolar = await _context.ApoioEscolar
				.FirstOrDefaultAsync(m => m.Codigo == id);
			if (apoioEscolar == null)
			{
				return NotFound();
			}

			return View(apoioEscolar);
		}

		// POST: ApoiosEscolar/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var apoioEscolar = await _context.ApoioEscolar.FindAsync(id);
			_context.ApoioEscolar.Remove(apoioEscolar);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ApoioEscolarExists(int id)
		{
			return _context.ApoioEscolar.Any(e => e.Codigo == id);
		}
	}
}
