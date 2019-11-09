using System.Collections.Generic;
using System.Linq;

using HotChocolate;
using HotChocolate.Types;

public class Query
{
    [GraphQLNonNullType]
    public List<Book> Books() => GetBooks();
    public Book Book(int id) => GetBooks().FirstOrDefault(x => x.Id == id);

//    protected override Configure(IObjectTypeDescriptor descriptor)
//    {
//        descriptor.Field( "book").Type<BooleanType>().Argument("id", a => a.Type<IdType>())
//            .Resolver( )
//    }

    static List<Book> GetBooks()
    {
        var books = new List<Book>{
            new Book {
                Id= 1,
                Title= "Fullstack tutorial for GraphQL",
                Pages= 356
            },
            new Book
            {
                Id= 2,
                Title= "Introductory tutorial to GraphQL",
                Chapters= 10
            },
            new Book
            {
                Id = 3,
                Title= "GraphQL Schema Design for the Enterprise",
                Pages= 550,
                Chapters= 25
            }
        };

        return books;
    }
}