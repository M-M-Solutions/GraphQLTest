using GraphQLTest.Data;
using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Repositories
{
    public class StarshipRepository
    {
        private readonly SWDbContext _dbContext;
        public StarshipRepository(SWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Starship>> GetStarshipsWithId(int characterId)
        {
            return await _dbContext.Starships.Where(pr => pr.CharacterId == characterId).ToListAsync();
        }

        public async Task<ILookup<int, Starship>> GetStarshipsForIds(IEnumerable<int> characterIds)
        {
            var starships = await _dbContext.Starships.Where(pr => characterIds.Contains(pr.CharacterId)).ToListAsync();
            return starships.ToLookup(r => r.CharacterId);
        }
        public async Task<Starship> AddStarship(Starship starship)
        {
            _dbContext.Starships.Add(starship);
            await _dbContext.SaveChangesAsync();
            return starship;
        }
    }
}
