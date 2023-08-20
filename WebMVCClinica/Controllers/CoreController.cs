using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebMVCClinica.Data.Context;

using WebMVCClinica.Models;
using WebMVCClinica.ViewModels;

namespace WebMVCClinica.Controllers;


[Route("/api/[controller]/[action]")]
public class CoreController : ControllerBase
{
    private readonly AgendarPacienteContext _context;

    public CoreController(AgendarPacienteContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult SalvarHorarioDisponivel(
        [FromBody] AgendamentoDisponibilidadeSalvarViewModel agendamentoDisponibilidadeSalvar)
    {
        Paciente paciente = new Paciente();
        paciente.Nome = agendamentoDisponibilidadeSalvar.NomePaciente;
        paciente.Documento = agendamentoDisponibilidadeSalvar.DocumentoPaciente;
        paciente.Celular = agendamentoDisponibilidadeSalvar.CelularPaciente;
        _context.PACIENTES.Add(paciente);
        _context.SaveChanges();

        Agendamento agendamento = new Agendamento();
        agendamento.ProfissionalId = agendamentoDisponibilidadeSalvar.ProfissionalId;
        agendamento.PacienteId = paciente.PacienteId;
        agendamento.Inicio = agendamentoDisponibilidadeSalvar.DataAgendamento;
        _context.AGENDAMENTOS.Add(agendamento);
        _context.SaveChanges();

        return Ok();
    }

    [HttpGet]
    public ActionResult BuscarPacientesCadastrados()
    {
        var buscarPacientes = _context.PACIENTES.AsNoTracking().ToList();
        return Ok(buscarPacientes);
    }

    [HttpGet]
    public ActionResult BuscarAgendamentosCadastrados()
    {
        var buscarAgendamentos = _context.AGENDAMENTOS.AsNoTracking().ToList();
        return Ok(buscarAgendamentos);
    }

    [HttpPost]
    public ActionResult SalvarAgendamento(
        [FromBody] AgendamentoViewModel model)
    {
        var agendamentos = new Agendamento()
        {
            PacienteId = model.PacienteId,
            Inicio = model.Inicio,
            Termino = model.Termino,
        };
        _context.Add(agendamentos);
        _context.SaveChanges();

        return Ok(agendamentos);
    }

    [HttpPost]
    public ActionResult SalvarPaciente(
        [FromBody] PacienteSalvarViewModel pacienteSalvarViewModel)
    {
        var pacientes = new Paciente()
        {
            Nome = pacienteSalvarViewModel.Nome,
            Documento = pacienteSalvarViewModel.Documento,
            Celular = pacienteSalvarViewModel.Celular
        };
        _context.Add(pacientes);
        _context.SaveChanges();

        return Ok(pacientes);
    }

    [HttpPost]
    public ActionResult ConsultarHorarioDisponivel(
        [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)

    {
        List<ProfissionalParametro> profissionalParamentros = _context.PROFISSIONAISPARAMETROS.ToList();

        List<ProfisisonalEspecialidade> profissionaisEspecialidade = _context.PROFISSIONALESPECIALIDADES
                                        .Where(x => x.EspecialidadeId == agendamentoDisponibilidadeConsultarViewModel.EspecialidadeId).ToList();

        List<AgendamentoDisponibilidadeEspecialidadeViewModel> agendamentoDisponibilidadeEspecialidades = new List<AgendamentoDisponibilidadeEspecialidadeViewModel>();

        List<int> profissionaisId = profissionaisEspecialidade.Select(x => x.ProfissionalId).ToList();

        List<Profissional> profissionais = _context.PROFISSIONAIS.ToList();

        foreach (int profissionalId in profissionaisId)
        {

            ProfissionalParametro profissionalParametroInicioAtendimentoMatutino = profissionalParamentros.Find
                (x => x.Nome == ProfissionalParametroConstantes.INICIO_ATENDIMENTO_MATUTINO && x.ProfissionalId == profissionalId);

            ProfissionalParametro profissionalParametroFinalAtendimentoMatutino = profissionalParamentros.Find
                (x => x.Nome == ProfissionalParametroConstantes.FINAL_ATENDIMENTO_MATUTINO && x.ProfissionalId == profissionalId);

            ProfissionalParametro profissionalParametroInicioAtendimentoVespertino = profissionalParamentros.Find
                (x => x.Nome == ProfissionalParametroConstantes.INICIO_ATENDIMENTO_VERPERTINO && x.ProfissionalId == profissionalId);

            ProfissionalParametro profissionalParametroFinalAtendimentoVerpertino = profissionalParamentros.Find
                (x => x.Nome == ProfissionalParametroConstantes.FINAL_ATENDIMENTO_VERPERTINO && x.ProfissionalId == profissionalId);

            List<AgendamentoListaDiaTodoViewModel> agendamentosDisponiveis = new List<AgendamentoListaDiaTodoViewModel>();

            DateTime horaInicioAtendimentoMatutino = Convert.ToDateTime(profissionalParametroInicioAtendimentoMatutino.Valor);

            DateTime horaFinalAtendiomentoMatutino = DateTime.Parse(profissionalParametroFinalAtendimentoMatutino.Valor);

            DateTime horaInicioAtendimentoVerpertino = DateTime.Parse(profissionalParametroInicioAtendimentoVespertino.Valor);

            DateTime horaFinalAtendimentoVerpertino = DateTime.Parse(profissionalParametroFinalAtendimentoVerpertino.Valor);

            DateTime inicio = agendamentoDisponibilidadeConsultarViewModel.Inicio;

            DateTime final = agendamentoDisponibilidadeConsultarViewModel.Fim;

            DateTime horaAtendimentoDisponivel = new DateTime(inicio.Year, inicio.Month, inicio.Day, horaInicioAtendimentoMatutino.Hour, horaInicioAtendimentoMatutino.Minute, horaInicioAtendimentoMatutino.Second);

            while (horaAtendimentoDisponivel.Date <= final.Date)
            {
                if (horaAtendimentoDisponivel.TimeOfDay < horaInicioAtendimentoMatutino.TimeOfDay)
                {
                    horaAtendimentoDisponivel = horaAtendimentoDisponivel.AddHours(1);
                    continue;
                }
                if (horaAtendimentoDisponivel.TimeOfDay > horaFinalAtendiomentoMatutino.TimeOfDay && horaAtendimentoDisponivel.TimeOfDay < horaInicioAtendimentoVerpertino.TimeOfDay)
                {
                    horaAtendimentoDisponivel = horaAtendimentoDisponivel.AddHours(1);
                    continue;
                }
                if (horaAtendimentoDisponivel.TimeOfDay > horaFinalAtendimentoVerpertino.TimeOfDay)
                {
                    horaAtendimentoDisponivel = horaAtendimentoDisponivel.AddHours(1);
                    continue;
                }
                agendamentosDisponiveis.Add(new AgendamentoListaDiaTodoViewModel { Start = horaAtendimentoDisponivel });
                horaAtendimentoDisponivel = horaAtendimentoDisponivel.AddHours(1);
            }

            List<Agendamento> scheduledAppointments = _context.AGENDAMENTOS
                .Where(x => x.Inicio.Date >= agendamentoDisponibilidadeConsultarViewModel.Inicio.Date
                && x.Termino.Date <= agendamentoDisponibilidadeConsultarViewModel.Fim.Date
                && x.ProfissionalId == profissionalId).ToList();

            List<DateTime> avaliableAppointments = new List<DateTime>();

            foreach (AgendamentoListaDiaTodoViewModel agendamentoListaDiaTodo in agendamentosDisponiveis)
            {
                Agendamento agendamento = scheduledAppointments.Find(x => x.Inicio == agendamentoListaDiaTodo.Start);
                if (agendamento is null)
                {
                    avaliableAppointments.Add(agendamentoListaDiaTodo.Start);
                }
            }

            Profissional profissional = profissionais.Find(x => x.Id == profissionalId);

            AgendamentoDisponibilidadeEspecialidadeViewModel agendamentoDisponibilidadeEspecialidade = new AgendamentoDisponibilidadeEspecialidadeViewModel();
            agendamentoDisponibilidadeEspecialidade.Profissional = profissional;
            agendamentoDisponibilidadeEspecialidade.Disponibilidade = avaliableAppointments;
            agendamentoDisponibilidadeEspecialidades.Add(agendamentoDisponibilidadeEspecialidade);
        }
        return Ok(agendamentoDisponibilidadeEspecialidades);
    }
}











