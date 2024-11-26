using System.Globalization;
using LibraryHub.Models;
using LibraryHub.Models.Editions;
using LibraryHub.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


CultureInfo english = new CultureInfo("en-US");
Author author = new("Eric Evans", english);

Book book = new Book(
    "Domain-Driven Design: Tackling complexity in the Heart of Software",
    new AuthorsList([author]),
    new Release(
        new Publisher("Addison-Wesley Professional"),
        new OrdinalEdition(1),
        new Published(new FullDate(new DateOnly(2003, 08, 30))),
        english));

DateOnly yearStart = new(DateTime.Today.Year, 1, 1);

var (sure, possible) = CountBook(book, yearStart);
var prob = Math.Max(sure, possible * .8f);

var published = new GenericRepository<Book>(new List<Book>() { book }).GetAll()
    .Where(book => book.Release.Publication.isPublishedBefore(yearStart))
    .ToList();

(int published, int sureThing) CountBook(Book book, DateOnly onDate)
{
    var publication = book.Release.Publication;
    if (publication.isPublishedBefore(onDate)) return (1, 0);
    else if (publication is Published) return (0, 1);
    else return (0, 0);
}
