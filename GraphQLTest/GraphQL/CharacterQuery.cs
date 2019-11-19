using GraphQL.Types;
using GraphQLTest.Data.Entities;
using GraphQLTest.GraphQL.Types;
using GraphQLTest.Repositories;

namespace GraphQLTest.GraphQL
{
    public class CharacterQuery : ObjectGraphType
    {
        public CharacterQuery(CharacterRepository repo)
        {
            Field<ListGraphType<CharacterType>>(
                "characters",
                resolve: context => repo.GetAll()
                );

            Field<CharacterType>(
               "character",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
               { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<int>("id");
                   return repo.GetOne(id);
               }
           );

        }
    }
}
