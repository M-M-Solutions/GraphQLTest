using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Data
{
    public class SWDbContext : DbContext
    {
        public SWDbContext(DbContextOptions<SWDbContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Starship> Starships { get; set; }
        
    }
}
