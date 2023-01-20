namespace WebMVCClinica.Models
{
    public class ProfissionalParametro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public Profissional Profissional { get; set; }
        public int ProfissionalId { get; set; }
    }
}
