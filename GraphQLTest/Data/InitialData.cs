using GraphQLTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Data
{
    public static class InitialData
    {
        public static void Seed(this SWDbContext dbContext)
        {
            if (!dbContext.Characters.Any())
            {
                dbContext.Characters.Add(new Character
                {
                    Name = "Luke Skywalker",
                    HairColor = "blond",
                    Gender = "male",
                    Height = 172,
                    EyeColor = EyeColor.Blue,
                    Starships = new List<Starship>
                    {
                        new Starship
                        {
                            Name = "X-wing",
                            Passengers = 0,
                            StarshipClass = "Starfighter"
                        },
                        new Starship
                        {
                            Name = "Imperial shuttle",
                            Passengers = 20,
                            StarshipClass = "Armed government transport"
                        }
                    }
                });

                dbContext.Characters.Add(new Character
                {
                    Name = "C-3PO",
                    HairColor = "n/a",
                    Gender = "n/a",
                    Height = 167,
                    EyeColor = EyeColor.Yellow
                });

                dbContext.Characters.Add(new Character
                {
                    Name = "R2-D2",
                    HairColor = "n/a",
                    Gender = "n/a",
                    Height = 96,
                    EyeColor = EyeColor.Red,
                });

                dbContext.Characters.Add(new Character
                {
                    Name = "Darth Vader",
                    HairColor = "none",
                    Gender = "male",
                    Height = 202,
                    EyeColor = EyeColor.Yellow,
                    Starships = new List<Starship>
                    {
                        new Starship
                        {
                            Name = "TIE Advanced x1",
                            Passengers = 0,
                            StarshipClass = "Starfighter"
                        },
                    }
                });

                dbContext.Characters.Add(new Character
                {
                    Name = "Leia Organa",
                    HairColor = "brown",
                    Gender = "female",
                    Height = 150,
                    EyeColor = EyeColor.Brown
                });

                dbContext.SaveChanges();
            }
        }
    }
}
