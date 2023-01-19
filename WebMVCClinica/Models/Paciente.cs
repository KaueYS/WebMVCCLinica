using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebMVCClinica.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        [JsonIgnore]
        public List<Agendamento> Agendamentos { get; set;}
    }
}
