using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
		private readonly ISuperHeroService _superHeroservice;	
        public SuperHeroController(ISuperHeroService superHeroService)

        {
			_superHeroservice = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {

			return await _superHeroservice.GetHeroes();
			
			
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
		{
			var result = _superHeroservice.GetHero(id);
			if (result == null) return NotFound("Hero not found");
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero hero)
		{
			var result = _superHeroservice.CreateHero(hero);
			

			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
		{
			var result = _superHeroservice.UpdateHero(id, request);
			if (result is null) return NotFound("Hero not found");

			return Ok(result);
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
		{
			var result = _superHeroservice.DeleteHero(id);
			if (result is null) return NotFound("Hero not found");

			return Ok(result);
		}

	}
}
