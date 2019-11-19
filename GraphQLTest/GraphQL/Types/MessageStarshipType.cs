using GraphQL.Types;
using GraphQLTest.GraphQL.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL.Types
{
    public class MessageStarshipType : ObjectGraphType<MessageStarship>
    {
        public MessageStarshipType()
        {
            Field(t => t.CharacterId);
            Field(t => t.Name);
        }
    }
}
