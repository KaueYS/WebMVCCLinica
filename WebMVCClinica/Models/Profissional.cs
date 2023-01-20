using System.Collections.Generic;

namespace WebMVCClinica.Models
{
    public class Profissional
    {
        public int Id { get; set; } 
        public string Nome { get; set; }

        public List<ProfissionalParametro> ProfissionalParametro { get;set; }
    }
}
