using System;
using System.Text.Json.Serialization;

namespace WebMVCClinica.Models
{
    
    public class Agendamento
    {
        public Agendamento()
        {

        }
        public Agendamento(int agendamentoId, DateTime inicio, DateTime termino, Paciente paciente, int pacienteId)
        {
            AgendamentoId = agendamentoId;
            Inicio = inicio;
            Termino = termino;
            Paciente = paciente;
            PacienteId = pacienteId;
        }

        

        public int AgendamentoId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        [JsonIgnore]
        public Paciente Paciente { get; set; }
        [JsonIgnore]
        public int PacienteId { get; set; }
       
    }   
}
