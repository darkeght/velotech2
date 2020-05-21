using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using velotech.Models;

namespace velotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroesController : ControllerBase
    {
        private readonly CadastroContext _context;

        public CadastroesController(CadastroContext context)
        {
            _context = context;
        }

        // GET: api/Cadastroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetCadastros()
        {
            return await _context.Cadastros.ToListAsync();
        }

        // GET: api/Cadastroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> GetCadastro(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return cadastro;
        }

        // PUT: api/Cadastroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastro(int id, Cadastro cadastro)
        {
            if (id != cadastro.Id) //teste
            {
                return BadRequest();
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cadastroes
        [HttpPost]
        public async Task<ActionResult<Cadastro>> PostCadastro(Cadastro cadastro)
        {
            var item = _context.Cadastros.FirstOrDefault(x => x.CpfCnpj == cadastro.CpfCnpj);

            if (item != null)
            {
                item.CpfCnpj = cadastro.CpfCnpj;
                item.Mae = cadastro.Mae;
                item.Nome = cadastro.Nome;
                item.Pai = cadastro.Pai;
                item.Rg = cadastro.Rg;
                item.Nascimento = cadastro.Nascimento;
                item.Emissor = cadastro.Emissor;

                _context.Cadastros.Update(item);
            }
            else
            {
                _context.Cadastros.Add(cadastro);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastro", new { id = cadastro.Id }, cadastro);
        }

        // DELETE: api/Cadastroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cadastro>> DeleteCadastro(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();

            return cadastro;
        }

        private bool CadastroExists(int id)
        {
            return _context.Cadastros.Any(e => e.Id == id);
        }
    }
}
