using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_intro_web_core
{
    public class Mutation
    {
        //TODO: use input type as parameter or configure descriptor to make non-null parameter
        public async Task<Book> Book([Service] BookDbContext dbContext, string title, int pages, string author,
            int chapters)
        {
            var book = new Book {Title = title, Chapters = chapters, Pages = pages, Author = new Author {Name = author}};
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return book;
        }
    }
}