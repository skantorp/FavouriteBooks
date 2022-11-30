using Books.BusinessLogic.MappingProfiles;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer;
using Books.DataAccessLayer.Interfaces;
using Books.DataAccessLayer.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DtoProfile));
builder.Services.AddMediatR(typeof(CreateBookRequest).Assembly);
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlServer(builder.Configuration
                    .GetConnectionString("BooksDbConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
