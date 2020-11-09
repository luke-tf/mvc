using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio_MVC.DTO
{
    public class FuncionarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Cargo do funcionário é obrigatório")]
        [StringLength(255,ErrorMessage="Cargo muito grande, tente um menor")]
        [MinLength(2,ErrorMessage="Cargo deve conter no mínimo 2 caracteres")]
        public string Cargo { get; set; }
        
        public DateTime Inicio_Wa { get; set; }
        
        [Required(ErrorMessage="Matrícula do funcionário é obrigatório")]
        [StringLength(255,ErrorMessage="Matrícula muito grande, tente uma menor")]
        [MinLength(2,ErrorMessage="Matrícula deve conter no mínimo 2 caracteres")]
        public string Matricula { get; set; }
        
        [Required(ErrorMessage="Nome do funcionário é obrigatório")]
        [StringLength(255,ErrorMessage="Nome do funcionário muito grande, tente uma menor")]
        [MinLength(2,ErrorMessage="Nome do funcionário deve conter no mínimo 2 caracteres")]
        public string Nome { get; set; }
        
        public DateTime Termina_Wa { get; set; }
        
        [Required(ErrorMessage="Local de trabalho do funcionário é obrigatório")]
        public int Gft_Id { get; set; }
        public int Vaga_Id { get; set; }
    }
}