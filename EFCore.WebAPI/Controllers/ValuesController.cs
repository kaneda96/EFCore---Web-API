using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult<IEnumerable<string>> GetFiltro(string nome)
        {
            var listHerois = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();
            return Ok(listHerois);
        }

        [HttpGet("Atualizar/{HeroiID}/{NomeHeroi}")]
        public ActionResult<string> Atualizar(int HeroiId,string NomeHeroi)
        {
            var heroi = _context.Herois.Single(l => l.Id == HeroiId);
            heroi.Nome = NomeHeroi;
            _context.Update(heroi);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/values/5
        [HttpGet("Inserir/{nmHero}")]
        public ActionResult<string> Inserir(string nmHero)
        {
            var heroi = new Domain.Heroi() {Nome = nmHero };
           
                //context.Herois.Add(heroi);
                _context.Add(heroi);
                _context.SaveChanges();
           
            return Ok();
        }     
        
        [HttpGet("AddRange")]
        public ActionResult<string> AddRange()
        {
            var herois = new List<Domain.Heroi>()
            {
                new Domain.Heroi(){Nome = "Hulk" },
                new Domain.Heroi(){Nome = "Loki" },
                new Domain.Heroi(){Nome = "Visão" }
            };

            _context.AddRange(herois);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.Single(l => l.Id == id);

            _context.Remove(heroi);
            _context.SaveChanges();
            
        }
    }
}
