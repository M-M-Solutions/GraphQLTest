using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLTest.GraphQL.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL
{
    public class CharacterSubscription : ObjectGraphType
    {
        public CharacterSubscription(MessageStarshipService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "starshipAdded",
                Type = typeof(MessageStarship),
                Resolver = new FuncFieldResolver<MessageStarship>(c => c.Source as MessageStarship),
                Subscriber = new EventStreamResolver<MessageStarship>(c => messageService.GetMessages())
            });
        }
    }
}
