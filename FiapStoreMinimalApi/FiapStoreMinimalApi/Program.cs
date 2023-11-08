using FiapStore.Entities;
using FiapStore.Interface;
using FiapStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user", (IUserRepository repository) => repository.GetAll());

app.MapGet("/user/{id}",(IUserRepository repository, int id) => repository.GetById(id));

app.MapPost("/user",(IUserRepository repository, User user) => repository.Create(user));

app.MapPut("/user",(IUserRepository repository, User user) => repository.Update(user));

app.MapDelete("/user/{id}",(IUserRepository repository, int id) => repository.Delete(id));

app.Run();

