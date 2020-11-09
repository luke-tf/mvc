using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_MVC.Models
{
    public class Vaga
    {
        [Required]
        public int Id { get; set; }
        public DateTime Abertura_Vaga { get; set; }
        [Required(ErrorMessage="É necessário colocar o código da vaga")]
        public string Codigo_Vaga { get; set; }
        public string Descricao_Vaga { get; set; }
        public string Projeto { get; set; }
        public int Qtd_Vaga { get; set; }
        public ICollection<Vaga_Tecnologia> VagaTecs { get; set; }
    }
}