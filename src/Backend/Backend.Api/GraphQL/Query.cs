namespace Wotan.Backend.Api.GraphQL;

[QueryType]
[GraphQLDescription("All supported queries")]
public class Query
{
    public Book GetBook()
        => new Book(
            Title: "Some Book title",
            Year: 1234,
            Author: new Author(
                Age: 123,
                Name: "Some Author name"));
}

// tmp records used for schema generation
public record Book(string Title, int Year, Author Author);
public record Author(int Age, string Name);