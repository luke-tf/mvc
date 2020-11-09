using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafio_MVC.Models;
using Desafio_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio_MVC.Controllers
{
    public class AwController : Controller
    {
        private readonly ApplicationDbContext database;
        public AwController(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Indx()
        {
            return View();
        }
        public IActionResult Funcionarios()
        {
            var func = database.Funcionarios.ToList();
            ViewBag.Gfts = database.Gfts.ToList();
            return View(func);
        }
        public IActionResult Vagas()
        {
            var vagas = database.Vagas.ToList();
            return View(vagas);
        }
        public IActionResult Historico()
        {
            return View();
        }
    }
}