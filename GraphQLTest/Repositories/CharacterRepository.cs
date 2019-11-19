using GraphQLTest.Data;
using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Repositories
{
    public class CharacterRepository
    {
        private readonly SWDbContext _dbContext;

        public CharacterRepository(SWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Character>> GetAll() => _dbContext.Characters.ToListAsync();

        public Task<Character> GetOne(int id) => _dbContext.Characters.SingleAsync(p => p.Id == id);
    }
}
