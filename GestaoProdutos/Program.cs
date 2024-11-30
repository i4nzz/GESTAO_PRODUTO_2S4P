using GestaoProduto.Data.Repository;
using GestaoProduto.Domain.Interfaces;
using GestaoProduto.Services.Services;
using GestaoProduto.Domain.Interfaces;
using GestaoProduto.Services.Interfaces;
using GestaoProduto.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<AppDBContext>();
builder.Services.AddDbContext<AppDBContext>
    (
        options =>
        {
            options.UseSqlServer
            (
                builder.Configuration.GetConnectionString("DefaultConnection")
            );
        }
    );





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();


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
