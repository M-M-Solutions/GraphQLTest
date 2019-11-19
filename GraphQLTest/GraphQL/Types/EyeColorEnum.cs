using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL.Types
{
    public class EyeColorEnum : EnumerationGraphType<Data.EyeColor>
    {
        public EyeColorEnum()
        {
            Name = "Color";
            Description = "The color of character eyes";
        }
    }
}
