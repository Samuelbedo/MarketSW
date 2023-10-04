using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("/api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpGet("{Id=int}")]
        public async Task<ActionResult> Get(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync
                (c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);

        }

        [HttpPost]
        public async Task<IActionResult> Post(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }

        [HttpPut]
        public async Task<IActionResult> Put(City city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }

        [HttpDelete("{id:int}")]//para borrar necesito el id del que voy a borrar
        public async Task<IActionResult> Delete(int id)
        {
            var FilaAfectada = await _context.Cities.Where(c => c.Id == id).ExecuteDeleteAsync();
            if (FilaAfectada == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
