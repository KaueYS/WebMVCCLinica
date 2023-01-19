using System;
using System.Collections.Generic;

namespace SimulacaoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Opcao1();
            CheckAppointmentInverted();
        }
        static void CheckAppointmentInverted()
        {
            //listar todos os horarios da agenda
            List<int> avaliables = new List<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            //lista os horarios ja agendados
            List<int> scheduledAppointments = new List<int> { 9, 10, 11, 18 };

            //lista de horarios disponiveis
            List<int> avaliableAppointments = new List<int>();

            //popular os horarios de toda a agenda na variavel hour.
            foreach (int hour in avaliables)
            {
                //encontrar (na lista dos horarios ja agendados) o correspondente que vem da lista dos horarios da agenda do dia) 
                int hourFind = scheduledAppointments.Find(x => x == hour);

                // se hourfind for igual a 0
                if (hourFind == 0)
                {
                    //salve na lista de horarios disponiveis 
                    avaliableAppointments.Add(hour);
                }
            }
            // loop para mostrar os horarios disponiveis na var item
            foreach (int item in avaliableAppointments)
            {
                Console.WriteLine("Hour avaliable: " + item);
            }
        }
        private static void Opcao1()
        {
            List<int> agendamentos = new List<int>();
            List<int> agendamentosLivres = new List<int>();


            agendamentos.Add(8);
            agendamentos.Add(9);
            agendamentos.Add(11);


            int ultimoHorario = 18;



            for (int i = 0; i < agendamentos.Count; i++)
            {
                bool aindaExisteAgendandamentosLivres = true;
                int novoHorario = 0;
                int horarioDoAgendamento = agendamentos[i];
                int intervalo = 1;
                while (aindaExisteAgendandamentosLivres)
                {
                    novoHorario = horarioDoAgendamento + intervalo;

                    int agendamentoExistente = agendamentos.Find(x => x == novoHorario);
                    if (agendamentoExistente == 0)
                    {
                        agendamentosLivres.Add(novoHorario);
                        intervalo++;
                    }
                    else
                    {
                        aindaExisteAgendandamentosLivres = false;
                    }

                    if (novoHorario == ultimoHorario)
                    {
                        break;
                    }
                }
            }
        }
    }
}
