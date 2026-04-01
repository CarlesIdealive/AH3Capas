using ApplicationComponent;
using Domain.Interfaces;
using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ItemsDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddTransient<IRepository, ItemRepository>();
builder.Services.AddTransient<ICommonRepository<Note>, NoteRepository>();
builder.Services.AddTransient<IService, ItemService>();
builder.Services.AddTransient<ICommonService<Note>, NoteService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/items", async (IService service) =>  await service.GetAsync()).WithName("GetItems");
app.MapPost("/items", async (string title, IService service) => {
    await service.AddAsync(title);
    return Results.Created();
}).WithName("AddItem");

app.MapGet("/notes", async (ICommonService<Note> service) => await service.GetAsync()).WithName("GetNotes");
app.MapPost("/notes", async (int id, string message, int itemId, ICommonService<Note> service) => {
    var note = new Note(id, itemId , message);
    await service.AddAsync(note);
    return Results.Created();
}).WithName("AddNote");


app.Run();

