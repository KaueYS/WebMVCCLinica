using System;

namespace WebMVCClinica.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
    }
}
