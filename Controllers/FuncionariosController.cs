using Desafio_MVC.DTO;
using Microsoft.AspNetCore.Mvc;
using Desafio_MVC.Models;
using Desafio_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext database;
        public FuncionariosController(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult AddDados()
        {
            Gft gft1 = new Gft();
            gft1.Cep = "06454-000";
            gft1.Cidade = "Barueri";
            gft1.Endereco = "Alameda Rio Negro, nº 585 Ed. Padauiri, 10º andar - Alphaville";
            gft1.Estado = "SP";
            gft1.Nome = "GFT Alphaville";
            gft1.Telefone = "11 2176-3253";
            Gft gft2 = new Gft();
            gft2.Cep = "80230-010";
            gft2.Cidade = "Curitiba";
            gft2.Endereco = "Av. Sete de Setembro, 2451 Torre Trinity Corporate, 6º andar - Rebouças";
            gft2.Estado = "PR";
            gft2.Nome = "GFT Curitiba";
            gft2.Telefone = "41 4009-5700";
            Gft gft3 = new Gft();
            gft3.Cep = "18095-450";
            gft3.Cidade = "Sorocaba";
            gft3.Endereco = "Av. São Francisco, 98 Jardim Sta. Rosália";
            gft3.Estado = "SP";
            gft3.Nome = "GFT Sorocaba";
            gft3.Telefone = "11 2176-3253";

            List<Gft> gftsList = new List<Gft>();
            gftsList.Add(gft1);
            gftsList.Add(gft2);
            gftsList.Add(gft3);

            database.AddRange(gftsList);
            database.SaveChanges();

            Funcionario func1 = new Funcionario();
            func1.Cargo = "Analista de Sistemas";
            func1.Inicio_Wa = DateTime.Now;
            func1.Matricula = "797228";
            func1.Nome = "Henrique Vergara";
            func1.Termino_Wa = DateTime.Now.AddDays(15);
            
            Funcionario func2 = new Funcionario();
            func2.Cargo = "Analista de Sistemas";
            func2.Inicio_Wa = DateTime.Now;
            func2.Matricula = "057100";
            func2.Nome = "Clecio Silva";
            func2.Termino_Wa = DateTime.Now.AddDays(15);

            List<Funcionario> funcsList = new List<Funcionario>();
            funcsList.Add(func1);
            funcsList.Add(func2);

            database.AddRange(funcsList);
            database.SaveChanges();

            Vaga v1 = new Vaga();
            v1.Projeto = "Itaú";
            v1.Descricao_Vaga = "Desenvolvedor Java Senior";
            v1.Abertura_Vaga = DateTime.Now;
            v1.Codigo_Vaga = "#ITAU2991";
            v1.Qtd_Vaga = 3;

            Vaga v2 = new Vaga();
            v2.Projeto = "Santander";
            v2.Descricao_Vaga = "Desenvolvedor iOS";
            v2.Abertura_Vaga = DateTime.Now;
            v2.Codigo_Vaga = "#SANT2020";
            v2.Qtd_Vaga = 1;

            List<Vaga> VagaList = new List<Vaga>();
            VagaList.Add(v1);
            VagaList.Add(v2);

            database.AddRange(VagaList);
            database.SaveChanges();

            return RedirectToAction("Indx","Aw");
        }

        [HttpGet("Aw/Funcionarios/Cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Gfts = database.Gfts.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Salvar(FuncionarioDTO funcTemp)
        {
            if(ModelState.IsValid)
            {
                Funcionario func = new Funcionario();
                func.Matricula = funcTemp.Matricula;
                func.Cargo = funcTemp.Cargo;
                func.Nome = funcTemp.Nome;
                func.Inicio_Wa = DateTime.Now;
                func.Termino_Wa = DateTime.Now.AddDays(15);
                
                database.Funcionarios.Add(func);
                database.SaveChanges();
                return RedirectToAction("Funcionarios","Aw");
            }
            else
            {
                ViewBag.Gft = database.Gfts.ToList();
                return RedirectToAction("Cadastrar","Funcionarios");
            }
        }
        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id>0)
            {
                var func = database.Funcionarios.First(x => x.Id == id);
                database.Funcionarios.Remove(func);
                database.SaveChanges();
            }
            return RedirectToAction("Funcionarios","Aw");
        }
    }
}