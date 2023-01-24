using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebMVCClinica.Models
{
    public class Profissional
    {
        

        public int Id { get; set; } 
        public string Nome { get; set; }

        [JsonIgnore]
        public List<ProfissionalParametro> ProfissionalParametro { get;set; }
    }
}
