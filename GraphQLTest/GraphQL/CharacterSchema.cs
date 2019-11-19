using GraphQL;
using GraphQL.Types;

namespace GraphQLTest.GraphQL
{
    public class CharacterSchema : Schema
    {
        public CharacterSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CharacterQuery>();
            Mutation = resolver.Resolve<CharacterMutation>();
        }
    }
}
