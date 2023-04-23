
namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
		Task<List<SuperHero>> GetHeroes();
		Task<SuperHero?> GetHero(int id);
		Task<List<SuperHero>> CreateHero(SuperHero hero);
		Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero);
		Task<List<SuperHero>?> DeleteHero(int id);


	}
}
