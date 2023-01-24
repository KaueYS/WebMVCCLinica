using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMVCClinica.Data.Context;
using WebMVCClinica.Models;
using WebMVCClinica.ViewModels;

namespace WebMVCClinica.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class ProfissionalParametrosController : Controller
    {
        private readonly AgendarPacienteContext _context;

        public ProfissionalParametrosController(AgendarPacienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] ProfissionalParametroViewModel model)
        {
            ProfissionalParametro profissionalParametro = new ProfissionalParametro
            {
                Id= model.Id,
                Nome= model.Nome,
                Valor = model.Valor,
                ProfissionalId= model.ProfissionalId,
            };

            _context.Add(profissionalParametro);
            _context.SaveChanges();
            return Ok(profissionalParametro);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var profissionalParametro = _context.PROFISSIONAISPARAMETROS.ToList();
            return Ok(profissionalParametro);
        }
    }
}
