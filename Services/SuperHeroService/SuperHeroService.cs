
namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {

		private readonly DataContext _context;

		public SuperHeroService(DataContext context)
		{
			_context = context;
		}
		public async Task<List<SuperHero>> CreateHero(SuperHero hero)
		{
			_context.SuperHeroes.Add(hero);
			await _context.SaveChangesAsync();
			return await _context.SuperHeroes.ToListAsync();
		}

		public async Task<List<SuperHero>?> DeleteHero(int id)
		{
			var hero = await _context.SuperHeroes.FindAsync(id);
			if (hero is null)
				return null;

			_context.SuperHeroes.Remove(hero);
			await _context.SaveChangesAsync();

			return await _context.SuperHeroes.ToListAsync();
		}


		public async Task<SuperHero?> GetHero(int id)
        {
			var hero = await _context.SuperHeroes.FindAsync(id);
			if (hero is null)
				return null;

			return hero;
		}

        public async Task<List<SuperHero>> GetHeroes()
        {
			var heroes = await _context.SuperHeroes.ToListAsync();
			return heroes;
        }

		public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
		{
			var hero = await _context.SuperHeroes.FindAsync(id);
			if (hero is null)
				return null;

			hero.FirstName = request.FirstName;
			hero.LastName = request.LastName;
			hero.Name = request.Name;
			hero.Location = request.Location;

			await _context.SaveChangesAsync();

			return await _context.SuperHeroes.ToListAsync();
		}
	}
}
