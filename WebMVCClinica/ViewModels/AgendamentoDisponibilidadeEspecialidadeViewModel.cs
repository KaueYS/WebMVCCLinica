using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using WebMVCClinica.Models;

namespace WebMVCClinica.ViewModels
{
    public class AgendamentoDisponibilidadeEspecialidadeViewModel
    {
        public Profissional Profissional { get; set; }
        public List<DateTime> Disponibilidade { get; set; }
        
    }
}
