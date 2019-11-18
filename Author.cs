using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AuthorType
        : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.AsNode()
                .IdField(t => t.Id)
                .NodeResolver((context, id) =>
                {
                    throw new NotImplementedException();
                });

            descriptor.Field(t => t.Name).Type<NonNullType<StringType>>();
        }
    }

    public class AuthorInputType
        : InputObjectType<Author>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(t => t.Name).Type<NonNullType<StringType>>();
        }
    }
}