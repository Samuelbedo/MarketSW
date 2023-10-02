using Market.API.Data;
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
        [HttpGet("{Id=Int}")]
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
    }
}
