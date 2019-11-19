using GraphQL.Types;
using GraphQLTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL.Types
{
    public class StarshipType : ObjectGraphType<Starship>
    {
        public StarshipType()
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("Starship name");
            Field(t => t.Passengers).Description("Number of max passengers");
            Field(t => t.StarshipClass);
        }
    }
}
