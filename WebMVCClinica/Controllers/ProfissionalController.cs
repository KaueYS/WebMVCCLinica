using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMVCClinica.Data.Context;
using WebMVCClinica.Models;
using WebMVCClinica.ViewModels;

namespace WebMVCClinica.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class ProfissionalController : Controller
    {
        private readonly AgendarPacienteContext _context;

        public ProfissionalController(AgendarPacienteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var profissionaisCadastrados = _context.PROFISSIONAIS.ToList();
            return Ok(profissionaisCadastrados);
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] ProfissionalViewModel model)
        {
            Profissional profissional = new Profissional
            {
                Id = model.Id,
                Nome= model.Nome,
            };
            _context.Add(profissional);
            _context.SaveChanges();
            return Ok(profissional);
         
        }
    }
}
