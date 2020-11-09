namespace Desafio_MVC.Models
{
    public class Funcionario_Tecnologia
    {
        public int Funcionario_Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Tecnologia_Id { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}