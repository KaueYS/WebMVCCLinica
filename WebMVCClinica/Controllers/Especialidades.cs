using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebMVCClinica.Data.Context;
using WebMVCClinica.Models;
using WebMVCClinica.ViewModels;

namespace WebMVCClinica.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class Especialidades : ControllerBase
    {
        private readonly AgendarPacienteContext _context;

        public Especialidades(AgendarPacienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] EspecialidadeViewModel model)
        {
            Especialidade especialidade = new Especialidade
            {
                Id = model.Id,
                Descricao= model.Descricao,
            };

            _context.Add(especialidade);
            _context.SaveChanges();

            return Ok(especialidade);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var especialidade = _context.ESPECIALIDADES.AsNoTracking().ToList();
            if (especialidade is null)
            {
                NotFound("Não há especialidades cadastradas");
            }
            return Ok(especialidade);
        }
    }
}
