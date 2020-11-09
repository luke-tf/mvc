using System;
using System.Collections.Generic;

namespace Desafio_MVC.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public DateTime Inicio_Wa { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime Termino_Wa { get; set; }
        public Gft Gft_Id { get; set; }
        public Vaga Vaga_Id { get; set; }
        public ICollection<Funcionario_Tecnologia> FuncTecs { get; set; }
        
    }
}