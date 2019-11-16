using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

public class Query
{
    [GraphQLNonNullType]
    public List<Book> Books([Service] BookDbContext dbContext) =>  dbContext.Books.Include(x => x.Author).ToList(); 

    //By convention GetBook() will be recorded as book in the query field.
    public Book GetBook([Service] BookDbContext dbContext, int id) => dbContext.Books.FirstOrDefault(x => x.Id == id);

//    protected override Configure(IObjectTypeDescriptor descriptor)
//    {
//        descriptor.Field( "book").Type<BooleanType>().Argument("id", a => a.Type<IdType>())
//            .Resolver( )
//    }
}