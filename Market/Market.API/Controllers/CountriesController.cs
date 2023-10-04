using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{

    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController (DataContext context)
        {
            _context = context;
        }


        //lista de paises
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }


        //Get por parametro
        [HttpGet("{Id=int}")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync
                (c => c.Id == id);
            
            if(country == null)
            {
                return NotFound();
            }
            return Ok(country);
            
        }

        [HttpPost]//insertar registros
        public async Task<IActionResult> Post(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();//guarda en la tabla los datos
            return Ok(country);
        }

        [HttpPut]//update
        public async Task<IActionResult> Put(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilaAfectada = await _context.Countries.Where(c => c.Id == id).ExecuteDeleteAsync();
            if(FilaAfectada == 0)
            {
                return NotFound();
            }
            return NoContent();//204, borra, pero no me muestra que borro
        }
    }
}
