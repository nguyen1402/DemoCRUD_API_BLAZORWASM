using BlazorProduct.Api.Models;
using Microsoft.EntityFrameworkCore;
using BlazorProduct.Api.Responsitori;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBProducts>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("connec"));
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductResponsitori>();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CortPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CortPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
