using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostgreDB.DataAccess;
using PostgreDB.Model.DomainModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddDbContext<PostgreDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("pgConn"), x => x.MigrationsHistoryTable("_EfMigrations", builder.Configuration.GetSection("DbSchema").GetSection("pgSchema").Value)));
builder.Services.AddDbContext<PostgreDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("pgConn2"), x => x.MigrationsHistoryTable("_EfMigrations", builder.Configuration.GetSection("DbSchema").GetSection("pgSchema2").Value)));

//builder.Services.AddDbContext<PostgreDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("pgConn")));

//Identity User Configuration
builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<PostgreDBContext>().AddDefaultTokenProviders();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
