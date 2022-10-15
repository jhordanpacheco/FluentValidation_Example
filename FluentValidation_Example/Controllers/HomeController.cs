using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation_Example.Models;

namespace FluentValidation_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var alunos = new List<Aluno>();

            alunos.Add(new Aluno
            {
                Nome = "Marcelo Grohe",
                Email = "marcelogrohe@teste.com",
                DataNascimento = new System.DateTime(1987, 1, 13)
            });

            alunos.Add(new Aluno
            {
                Nome = "Post Malone",
                Email = "postmalone@teste.com",
                DataNascimento = new System.DateTime(1995, 7, 4)
            });

            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}