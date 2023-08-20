using System;

namespace WebMVCClinica.ViewModels
{
    public class AgendamentoDisponibilidadeSalvarViewModel
    {
        public int ProfissionalId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string NomePaciente { get; set; }
        public string DocumentoPaciente { get; set; }
        public string CelularPaciente { get; set; }
    }
}
