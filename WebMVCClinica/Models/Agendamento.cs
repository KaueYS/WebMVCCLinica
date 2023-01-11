using System;

namespace WebMVCClinica.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
    }
}
