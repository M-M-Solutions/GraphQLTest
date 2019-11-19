using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Data.Entities
{
    public class Starship
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public string Name { get; set; }
        public int Passengers { get; set; }
        public string StarshipClass { get; set; }
    }
}
