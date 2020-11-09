using Desafio_MVC.DTO;
using Microsoft.AspNetCore.Mvc;
using Desafio_MVC.Models;
using Desafio_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_MVC.Controllers
{
    public class VagasController : Controller
    {
        private readonly ApplicationDbContext database;
        public VagasController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("Aw/Vagas/Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(VagaDTO vagaTemp)
        {
            if(ModelState.IsValid)
            {
                Vaga vaga = new Vaga();
                vaga.Projeto = vagaTemp.Projeto;
                vaga.Abertura_Vaga = DateTime.Now;
                vaga.Codigo_Vaga = vagaTemp.Codigo_Vaga;
                vaga.Descricao_Vaga = vagaTemp.Descricao_Vaga;
                vaga.Qtd_Vaga = vagaTemp.Qtd_Vaga;
                
                database.Vagas.Add(vaga);
                database.SaveChanges();
                return RedirectToAction("Vagas","Aw");
            }
            else
            {
                return RedirectToAction("Cadastrar","Vagas");
            }
        }
        public IActionResult Deletar(int id)
        {
            if (id>0)
            {
                var vg = database.Vagas.First(x => x.Id == id);
                database.Vagas.Remove(vg);
                database.SaveChanges();
            }
            return RedirectToAction("Vagas","Aw");
        }
    }
}