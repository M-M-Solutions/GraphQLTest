using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Data.Entities
{
    public class Character
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public string HairColor { get; set; }
        public string Gender { get; set; }
        public int Height { get; set; }
        public EyeColor EyeColor { get; set; }
        public List<Starship> Starships { get; set; }
    }
}
