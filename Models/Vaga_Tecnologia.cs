namespace Desafio_MVC.Models
{
    public class Vaga_Tecnologia
    {
        public int Vaga_Id { get; set; }
        public Vaga Vaga { get; set; }
        public int Tecnologia_Id { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}