using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

public class Query
{
    // let the execution handle the to list in an async way
    [GraphQLNonNullType]
    public IEnumerable<Book> GetBooks([Service] BookDbContext dbContext) =>  
        dbContext.Books.Include(x => x.Author);

    //By convention GetBook() will be recorded as book in the query field.
    public Book GetBook([Service] BookDbContext dbContext, int id) => 
        dbContext.Books.FirstOrDefault(x => x.Id == id);
}