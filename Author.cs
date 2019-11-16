using HotChocolate;
using HotChocolate.Types;

public class Author
{
    
    [GraphQLType(typeof(NonNullType<IdType>))]
    public int Id { get; set; }
    [GraphQLNonNullType]
    public string Name { get; set; }
}