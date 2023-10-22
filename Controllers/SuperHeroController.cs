using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotNet7.Services.SuperHeroService;

namespace SuperHeroAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        //public async Task<IActionResult> GetAllHeroes()                   // This does not show the object under Schemas
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()     // This was the object is shown under Schemas
        {
            return _superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]                                                             // This must match with the paramaters from ActionResult
        //public async Task<IActionResult> GetSingleHero(int id)                    // This does not show the object under Schemas
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)      // This was the object is shown under Schemas
        {
            var result = _superHeroService.GetSingleHero(id);

            if (result == null)
            {
                return NotFound("The hero does not exist!");
            }

            return Ok(result);
        }

        [HttpPost]                                                             // This must match with the paramaters from ActionResult
        //public async Task<IActionResult> AddHero(int id)                    // This does not show the object under Schemas
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)      // This was the object is shown under Schemas
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]                                                             // This must match with the paramaters from ActionResult
        //public async Task<IActionResult> GetSingleHero(int id)                    // This does not show the object under Schemas
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)      // This was the object is shown under Schemas
        {
            var result = _superHeroService.UpdateHero(id, request);

            if (result == null)
            {
                return NotFound("The hero does not exist!");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]                                                             // This must match with the paramaters from ActionResult
        //public async Task<IActionResult> GetSingleHero(int id)                    // This does not show the object under Schemas
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)      // This was the object is shown under Schemas
        {
            var result = _superHeroService.DeleteHero(id);

            if (result == null)
            {
                return NotFound("The hero does not exist!");
            }

            return Ok(result);
        }
    }
}
