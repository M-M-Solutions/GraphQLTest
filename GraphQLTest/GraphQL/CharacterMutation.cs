using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.GraphQL.Types;
using GraphQLTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL
{
    public class CharacterMutation : ObjectGraphType
    {
        public CharacterMutation(StarshipRepository starshipRepo)
        {
            FieldAsync<StarshipType>(
                "createStarship",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "starship" }),
                resolve: async context =>
                {
                    var starship = context.GetArgument<Starship>("starship");
                    return await context.TryAsyncResolve(
                        async c => await starshipRepo.AddStarship(starship));
                });
        }
    }
}
