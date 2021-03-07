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
                                   }).ToListAsync());
            }
            else
            {
                return Json(new { status = "error", message = "error creating customer" });
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
            return View();
        }

        // POST: Avaliacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avaliacao);
        }

        // GET: Avaliacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return View(avaliacao);
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
    }
}
