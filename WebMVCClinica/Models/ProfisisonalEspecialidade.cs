using System.Collections.Generic;

namespace WebMVCClinica.Models
{
    public class ProfisisonalEspecialidade
    {
        public int Id { get; set; }
        public Profissional Profissional { get; set; }
        public int ProfissionalId { get; set; }
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }    
    }
}
