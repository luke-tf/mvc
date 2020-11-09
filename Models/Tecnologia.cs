using System.Collections.Generic;

namespace Desafio_MVC.Models
{
    public class Tecnologia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Funcionario_Tecnologia> FuncTecs { get; set; }
        public ICollection<Vaga_Tecnologia> VagaTecs { get; set; }
    }
}