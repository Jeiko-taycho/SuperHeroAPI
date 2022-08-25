using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase{
        private static List<Superhero> heroes = new List<Superhero> {
                new Superhero { Id=1, Name="Spider Man",Firstname="Peter",Lastname="Parker",Place="Mew York" }

            };
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get() {
          

            return Ok(heroes);
        }
    }
}
