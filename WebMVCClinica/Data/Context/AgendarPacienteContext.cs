using Microsoft.EntityFrameworkCore;
using WebMVCClinica.Models;

namespace WebMVCClinica.Data.Context
{
    public class AgendarPacienteContext : DbContext
    {
        public AgendarPacienteContext(DbContextOptions<AgendarPacienteContext> options) : base(options) 
        { 
        }

        public DbSet <Agendamento> AGENDAMENTOS { get; set; }
        public DbSet <Paciente> PACIENTES { get; set; }
        public DbSet<Profissional> PROFISSIONAIS { get;set; }
        public DbSet<ProfissionalParametro> PROFISSIONAISPARAMETROS { get; set; }
    }
}
