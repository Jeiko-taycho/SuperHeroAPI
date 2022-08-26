using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase {
        private static List<Superhero> heroes = new List<Superhero> {
                new Superhero { Id=1, Name="Spider Man",Firstname="Peter",Lastname="Parker",Place="Mew York" },
                new Superhero { Id=2, Name="Iron Man"  ,Firstname="Toni" ,Lastname="Stark" ,Place="Long Island"}

            };
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get() {
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> Get(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero) {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero request)
        {
            var hero = heroes.Find(x => x.Id == request.Id);
            if (hero == null) return BadRequest("Hero not found");
            hero.Name = request.Name;
            hero.Firstname = request.Firstname;
            hero.Lastname = request.Lastname;
            hero.Place = request.Place;

            return Ok(hero);    
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> Delete(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null) 
                return BadRequest("Hero not found");
            heroes.Remove(hero);
            return Ok(heroes);
        }

    }
}
