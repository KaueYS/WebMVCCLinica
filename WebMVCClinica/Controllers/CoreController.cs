using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        ProfissionalParametro profissionalParametroInicioAtendimentoMatutino = new ProfissionalParametro();
        profissionalParametroInicioAtendimentoMatutino.Id = 1;
        profissionalParametroInicioAtendimentoMatutino.Nome = "InicioAtendimentoMatutino";
        profissionalParametroInicioAtendimentoMatutino.Valor = "2023-01-13 09:00:00";
        profissionalParametroInicioAtendimentoMatutino.ProfissionalId = 20;

        ProfissionalParametro profissionalParametroFinalAtendimentoMatutino = new ProfissionalParametro();
        profissionalParametroFinalAtendimentoMatutino.Id = 2;
        profissionalParametroFinalAtendimentoMatutino.Nome = "FinalAtendimentoMatutino";
        profissionalParametroFinalAtendimentoMatutino.Valor = "2023-01-13 11:00:00";
        profissionalParametroFinalAtendimentoMatutino.ProfissionalId = 20;

        ProfissionalParametro profissionalParametroInicioAtendimentoVespertino = new ProfissionalParametro();
        profissionalParametroInicioAtendimentoVespertino.Id = 3;
        profissionalParametroInicioAtendimentoVespertino.Nome = "InicioAtendimentoVespertino";
        profissionalParametroInicioAtendimentoVespertino.Valor = "2023-01-13 13:00:00";
        profissionalParametroInicioAtendimentoVespertino.ProfissionalId = 20;

        ProfissionalParametro profissionalParametroFinalAtendimentoVerpertino = new ProfissionalParametro();
        profissionalParametroFinalAtendimentoVerpertino.Id = 4;
        profissionalParametroFinalAtendimentoVerpertino.Nome = "FinalAtendimentoVespertino";
        profissionalParametroFinalAtendimentoVerpertino.Valor = "2023-01-13 17:00:00";
        profissionalParametroFinalAtendimentoVerpertino.ProfissionalId = 20;





        List<AgendamentoListaDiaTodoViewModel> agendamentosDisponiveis = new List<AgendamentoListaDiaTodoViewModel>();
        //DateTime lastHour = new DateTime(2023, 01, 13, 7, 00, 00);
        DateTime lastHour = Convert.ToDateTime(profissionalParametroInicioAtendimentoMatutino.Valor);

        for (int i = 8; i <= 18; i++)
        {

            if (lastHour > Convert.ToDateTime(profissionalParametroFinalAtendimentoMatutino.Valor) 
                && lastHour < Convert.ToDateTime(profissionalParametroInicioAtendimentoVespertino.Valor))
            {
                lastHour = lastHour.AddHours(1);
                continue;
            }


            agendamentosDisponiveis.Add(new AgendamentoListaDiaTodoViewModel { Start = lastHour });
            lastHour = lastHour.AddHours(1);
        }

        List<Agendamento> scheduledAppointments = _context.AGENDAMENTOS.AsNoTracking().ToList();
        List<DateTime> avaliableAppointments = new List<DateTime>();

        foreach (AgendamentoListaDiaTodoViewModel agendamentoListaDiaTodo in agendamentosDisponiveis)
        {
            Agendamento agendamento = scheduledAppointments.Find(x => x.Inicio == agendamentoListaDiaTodo.Start);
            if (agendamento is null)
            {
                avaliableAppointments.Add(agendamentoListaDiaTodo.Start);
            }
        }
        return Ok(avaliableAppointments);


    }
}
//==============================================
//1 - Criar tabela Profissional (Id, nome)
// 2 - Tabela Profissional (Parametro -  ) 1--> N
//       Tabela ProfissionalParametro (Id, Nome, Valor, IdProfissional)

//==============================================
//[HttpPost]
//public ActionResult ConsultarHorarioDisponivel(
//        [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)
//{
//    List<AgendamentoListaDiaTodoViewModel> agendamentosDisponiveis = new List<AgendamentoListaDiaTodoViewModel>();
//    DateTime lastHour = new DateTime(2023, 01, 13, 7, 00, 00);

//    for (int i = 8; i <= 18; i++)
//    {
//        lastHour = lastHour.AddHours(1);
//        agendamentosDisponiveis.Add(new AgendamentoListaDiaTodoViewModel { Start = lastHour });
//    }

//    List<Agendamento> scheduledAppointments = _context.AGENDAMENTOS.AsNoTracking().ToList();
//    List<DateTime> avaliableAppointments = new List<DateTime>();

//    foreach (AgendamentoListaDiaTodoViewModel agendamentoListaDiaTodo in agendamentosDisponiveis)
//    {
//        Agendamento agendamento = scheduledAppointments.Find(x => x.Inicio == agendamentoListaDiaTodo.Start);
//        if (agendamento is null)
//        {
//            avaliableAppointments.Add(agendamentoListaDiaTodo.Start);
//        }
//    }
//    return Ok(avaliableAppointments);
//}

//[HttpPost]
//public ActionResult ConsultarDisponibilidade(
//    [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)
//{

//    var agendamentos = _context.AGENDAMENTOS.Where(x => x.Inicio.Date == agendamentoDisponibilidadeConsultarViewModel.Data.Date).ToList();
//    agendamentos = agendamentos.OrderBy(x => x.Inicio).ToList();

//    var intervalo = 30;
//    string ultimoHorario = "18:00";


//    List<Agendamento> agendamentosLivres = new List<Agendamento>();

//    for (int i = 0; i < agendamentos.Count; i++)
//    {
//        DateTime proximoInicio = agendamentos[i].Termino;
//        bool aindaExisteHorarioLivre = true;
//        while (aindaExisteHorarioLivre)
//        {
//            Agendamento agendametoExistente = agendamentos.Find(_ => _.Inicio == proximoInicio);
//            if (agendametoExistente is null)
//            {
//                DateTime inicio = proximoInicio;
//                DateTime termino = inicio.AddMinutes(intervalo);
//                if (inicio.TimeOfDay >= Convert.ToDateTime(ultimoHorario).TimeOfDay)
//                {
//                    break;
//                }
//                agendamentosLivres.Add(new Agendamento() { Inicio = inicio, Termino = termino });
//                proximoInicio = proximoInicio.AddMinutes(intervalo);
//            }
//            else
//            {
//                aindaExisteHorarioLivre = false;
//            }
//        }
//    }
//    return Ok(agendamentosLivres);
//}



//[HttpPost]
//public ActionResult ConsultarDisponibilidadeInvertida(
//    [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)
//{
//    List<DateTime> avaliables = new List<DateTime>();
//    avaliables.Add(new DateTime(2023, 1, 13, 8, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 9, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 10, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 11, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 12, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 13, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 14, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 15, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 16, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 17, 0, 0));
//    avaliables.Add(new DateTime(2023, 1, 13, 18, 0, 0));

//    List<DateTime> scheduledAppointments = new List<DateTime>();
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 9, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 10, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 11, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 18, 0, 0));

//    List<DateTime> avaliableAppointments = new List<DateTime>();
//    foreach (DateTime date in avaliables)
//    {
//        DateTime datetimeFind = scheduledAppointments.Find(x => x == date);
//        if (datetimeFind == DateTime.MinValue)
//        {
//            avaliableAppointments.Add(date);
//        }
//    }
//    return Ok(avaliableAppointments);

//}

//[HttpPost]
//public ActionResult ConsultarDisponibilidadeInvertidaObjeto(
//    [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)
//{
//    List<AgendamentoListaDiaTodoViewModel> agendamentosDisponiveis = new List<AgendamentoListaDiaTodoViewModel>();
//    DateTime lastHour = new DateTime(2023, 01, 13, 7, 00, 00);

//    for (int i = 8; i <= 18; i++)
//    {
//        lastHour = lastHour.AddHours(1);
//        agendamentosDisponiveis.Add(new AgendamentoListaDiaTodoViewModel { Start = lastHour });
//    }

//    List<DateTime> scheduledAppointments = new List<DateTime>();
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 9, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 10, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 11, 0, 0));
//    scheduledAppointments.Add(new DateTime(2023, 1, 13, 18, 0, 0));

//    List<DateTime> avaliableAppointments = new List<DateTime>();

//    foreach (AgendamentoListaDiaTodoViewModel agendamentoListaDiaTodo in agendamentosDisponiveis)
//    {
//        DateTime DataEHoraEncontrada = scheduledAppointments.Find(x => x == agendamentoListaDiaTodo.Start);
//        if (DataEHoraEncontrada == DateTime.MinValue)
//        {
//            avaliableAppointments.Add(agendamentoListaDiaTodo.Start);
//        }

//    }
//    return Ok(avaliableAppointments);


//}
//List<Agendamento> agendamentos = new List<Agendamento>();
//agendamentos.Add(new Agendamento
//{
//    Id = 1,
//    Inicio = new DateTime(2023, 1, 11, 8, 00, 00),
//    Termino = new DateTime(2023, 1, 11, 8, 30, 00)
//});
//agendamentos.Add(new Agendamento
//{
//    Id = 2,
//    Inicio = new DateTime(2023, 1, 11, 10, 30, 00),
//    Termino = new DateTime(2023, 1, 11, 11, 00, 00)
//});
//agendamentos.Add(new Agendamento
//{
//    Id = 3,
//    Inicio = new DateTime(2023, 1, 11, 10, 00, 00),
//    Termino = new DateTime(2023, 1, 11, 10, 30, 00)
//});

//agendamentos.Add(new Agendamento
//{
//    Id = 4,
//    Inicio = new DateTime(2023, 1, 12, 7, 00, 00),
//    Termino = new DateTime(2023, 1, 12, 7, 30, 00)
//});






