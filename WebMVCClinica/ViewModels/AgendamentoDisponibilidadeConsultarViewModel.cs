using System;

namespace WebMVCClinica.ViewModels
{
    public class AgendamentoDisponibilidadeConsultarViewModel
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int? EspecialidadeId { get; set; }
    }
}
