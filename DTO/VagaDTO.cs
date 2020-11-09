using System;
using System.ComponentModel.DataAnnotations;
using Desafio_MVC.Models;

namespace Desafio_MVC.DTO
{
    public class VagaDTO
    {
        [Required]
        public int Id { get; set; }
        public DateTime Abertura_Vaga { get; set; }
        [Required(ErrorMessage="É necessário preencher o código da vaga")]
        [StringLength(255,ErrorMessage="Código muito grande, tente um menor")]
        [MinLength(2,ErrorMessage="O código está muito curto")]
        public string Codigo_Vaga { get; set; }
        [Required(ErrorMessage="É necessário preencher a descrição da vaga")]
        [StringLength(255,ErrorMessage="Sua descrição está muito grande, tente uma descrição menor")]
        [MinLength(2,ErrorMessage="Sua descrição está muito curta")]
        public string Descricao_Vaga { get; set; }
        [Required(ErrorMessage="Este campo é obrigatório")]
        [StringLength(255,ErrorMessage="Nome do projeto ficou muito grande, tente um menor")]
        [MinLength(2,ErrorMessage="O nome do projeto está muito curto, tente um maior")]
        public string Projeto { get; set; }
        [Required(ErrorMessage="Este campo é obrigatório")]
        public int Qtd_Vaga { get; set; }
    }
}