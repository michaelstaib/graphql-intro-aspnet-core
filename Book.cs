using System;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int Chapters { get; set; }
        public Author Author { get; set; }
    }

    public class BookType
        : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.AsNode()
                .IdField(t => t.Id)
                .NodeResolver((context, id) =>
                {
                    throw new NotImplementedException();
                });
                
            descriptor.Field(t => t.Title).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Author).Type<NonNullType<AuthorType>>();
        }
    }

    public class BookInputType
        : InputObjectType<Book>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(t => t.Title).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Author).Type<NonNullType<AuthorInputType>>();
        }
    }
}