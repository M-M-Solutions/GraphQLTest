using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL.Types
{
    public class CharacterType : ObjectGraphType<Character>
    {
        public CharacterType(StarshipRepository characterRepo, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of character");
            Field(t => t.HairColor).Description("Character hair color");
            Field(t => t.Gender);
            Field(t => t.Height).Description("Character height");
            Field<EyeColorEnum>("Color", "The color of eyes");


            Field<ListGraphType<StarshipType>>(
                "starships",
                resolve: context =>
                {
                    ClaimsPrincipal user = (ClaimsPrincipal)context.UserContext;
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Starship>(
                            "GetReviewsByProductId", characterRepo.GetStarshipsForIds);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
