using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]//lista de estados
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.States.ToListAsync());
        }

        [HttpGet("{Id=int}")]//por parametro
        public async Task<ActionResult> Get(int id)
        {
            var state = await _context.States.FirstOrDefaultAsync
                (s => s.Id == id);

            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);

        }

        [HttpPost]//insertar registros
        public async Task<IActionResult> Post(State state)
        {
            _context.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpPut]//update
        public async Task<IActionResult> Put(State state)
        {
            _context.Update(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpDelete("{id:int}")]//para borrar necesito el id del que voy a borrar
        public async Task<IActionResult> Delete(int id)
        {
            var FilaAfectada = await _context.States.Where(s => s.Id == id).ExecuteDeleteAsync();
            if (FilaAfectada == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
