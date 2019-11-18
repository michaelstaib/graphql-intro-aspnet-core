using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
    public class Mutation
    {
        //TODO: use input type as parameter or configure descriptor to make non-null parameter
        public async Task<Book> Book([State("", IsScoped = true)]BookDbContext dbContext, Book book)
        {
            // we can automatically infer the book input
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return book;
        }
    }
}