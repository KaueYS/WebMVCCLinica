using System.Collections.Generic;

namespace WebMVCClinica.Models
{
    public class ProfisisonalEspecialidade
    {
        public int Id { get; set; }
        public List<Especialidade> Especialidades { get; set; }
    }
}
