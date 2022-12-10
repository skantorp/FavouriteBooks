using System.Text;
using API.Services;
using Books.Api.Extensions;
using Books.BusinessLogic.Commands;
using Books.BusinessLogic.MappingProfiles;
using Books.DataAccessLayer;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using Books.DataAccessLayer.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
	logging.ClearProviders();
	logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy("Default", policy =>
	{
		var allowedOrigins = builder.Configuration["AllowedOrigins"]?.Split(',');

		if (allowedOrigins != null && allowedOrigins.Length > 0)
		{
			policy.WithOrigins(allowedOrigins);
		}
		else
		{
			policy.AllowAnyOrigin();
		}

		policy.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});
builder.Services.AddAutoMapper(typeof(DtoProfile));
builder.Services.AddMediatR(typeof(CreateBook).Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<AuthService>();
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

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseCors("Default");

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();