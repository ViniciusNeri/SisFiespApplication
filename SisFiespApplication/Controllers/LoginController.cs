using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisFiespApplication.Models;

namespace SisFiespApplication.Controllers
{
	public class LoginController : Controller
	{
		private readonly Contexto _context;

		public LoginController(Contexto context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			if (HttpContext.Session.GetString("error") != null)
			{
				ViewBag.error = "Login e senha incorreta, verifique!";
				HttpContext.Session.Clear();
			}
			return View();
		}

		[HttpPost]
		public ActionResult Login()
		{
			string btnclick = Request.Form["btnLogin"].ToString();

			if (btnclick == "login")
			{
				string userName = Request.Form["userName"].ToString();
				string Password = Request.Form["password"].ToString();

				var usuario = (from data in _context.Usuario where data.Login == userName && data.Senha == Password select data).FirstOrDefault();

				if (usuario != null)
				{
					HttpContext.Session.SetString("userName", usuario.Login);
					HttpContext.Session.SetString("password", usuario.Senha);
					HttpContext.Session.SetInt32("usuarioCodigo", usuario.Codigo);
					HttpContext.Session.SetString("nome", usuario.Nome);

					return RedirectToAction("Index", "Home");

				}else if (usuario == null)
				{
					HttpContext.Session.SetString("error", "Erro");
					return RedirectToAction("Index");
				}

			}
			return View();
		}

		public ActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}
		// GET: LoginController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: LoginController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LoginController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: LoginController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: LoginController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: LoginController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: LoginController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
