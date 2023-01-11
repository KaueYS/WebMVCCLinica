using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using WebMVCClinica.Models;
using WebMVCClinica.ViewModels;

namespace WebMVCClinica.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class CoreController : Controller
    {
        [HttpPost]
        public ActionResult SalvarPaciente(
            [FromBody] PacienteSalvarViewModel pacienteSalvarViewModel)
        {

            return Ok(pacienteSalvarViewModel);
        }

        [HttpPost]
        public ActionResult ConsultarDisponibilidade(
            [FromBody] AgendamentoDisponibilidadeConsultarViewModel agendamentoDisponibilidadeConsultarViewModel)
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            agendamentos.Add(new Agendamento
            {
                Id = 1,
                Inicio = new DateTime(2023, 1, 11, 8, 00, 00),
                Termino = new DateTime(2023, 1, 11, 8, 30, 00)
            });
            agendamentos.Add(new Agendamento
            {
                Id = 2,
                Inicio = new DateTime(2023, 1, 11, 10, 30, 00),
                Termino = new DateTime(2023, 1, 11, 11, 00, 00)
            });
            agendamentos.Add(new Agendamento
            {
                Id = 3,
                Inicio = new DateTime(2023, 1, 11, 10, 00, 00),
                Termino = new DateTime(2023, 1, 11, 10, 30, 00)
            });

            agendamentos.Add(new Agendamento
            {
                Id = 4,
                Inicio = new DateTime(2023, 1, 12, 7, 00, 00),
                Termino = new DateTime(2023, 1, 12, 7, 30, 00)
            });
            agendamentos = agendamentos.Where(x => x.Inicio.Date == agendamentoDisponibilidadeConsultarViewModel.Data.Date).ToList();
            agendamentos = agendamentos.OrderBy(x => x.Inicio).ToList();
            int intervalo = 30;
            
            return Ok(agendamentoDisponibilidadeConsultarViewModel);
        }



    }
}
