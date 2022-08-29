using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase {

        public readonly DataContext _contex;
        public SuperHeroController(DataContext contex)
        {
            _contex = contex;
        }     

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get() {

            return Ok(await _contex.Superheroes.ToListAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> Get(int id)
        {
            var hero = await _contex.Superheroes.FindAsync (id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero) {
            
            _contex.Superheroes.Add(hero);
            await _contex.SaveChangesAsync();
            return Ok(await _contex.Superheroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero request)
        {
            var dbhero = await _contex.Superheroes.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Hero not found");
            dbhero.Name = request.Name;
            dbhero.Firstname = request.Firstname;
            dbhero.Lastname = request.Lastname;
            dbhero.Place = request.Place;

            await _contex.SaveChangesAsync();

            return Ok(dbhero);    
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> Delete(int id)
        {
            var dbhero = await _contex.Superheroes.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Hero not found");
            _contex.Superheroes.Remove(dbhero);

            await _contex.SaveChangesAsync();
            return Ok(await _contex.Superheroes.ToListAsync());
        }

    }
}
