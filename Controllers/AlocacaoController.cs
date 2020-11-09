using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafio_MVC.Models;
using Desafio_MVC.Data;
using Desafio_MVC.DTO;
using System;

namespace Desafio_MVC.Controllers
{
    public class AlocacaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public AlocacaoController(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            ViewBag.Funcionarios = database.Funcionarios.ToList();
            ViewBag.Vagas = database.Vagas.ToList();
            return View();
        }
        public IActionResult Alocar(AlocacaoDTO alocTemp)
        {
            var func = database.Funcionarios.First(x => x.Id == alocTemp.FuncionarioID);
            database.Funcionarios.Remove(func);
            AlocacaoDTO aloc = new AlocacaoDTO();
            aloc.Registro = DateTime.Now;            
            database.SaveChanges();

            return RedirectToAction("Funcionarios","Aw");
        }
    }
}