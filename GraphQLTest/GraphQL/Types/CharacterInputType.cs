using GraphQL.Types;

namespace GraphQLTest.GraphQL.Types
{
    public class CharacterInputType : InputObjectGraphType
    {
        public CharacterInputType()
        {
            Name = "starshipInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("passengers");
            Field<NonNullGraphType<IntGraphType>>("Passengers");
            Field<NonNullGraphType<IntGraphType>>("characterId");
        }
    }
}
