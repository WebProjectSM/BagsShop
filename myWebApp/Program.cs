using BusinessLayer;
using DataLayer;
using Entities;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Middlewares;
using myWebApp;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
var str = builder.Configuration.GetConnectionString("school");
builder.Services.AddDbContext<bagsContext>(optios => optios.UseSqlServer(str));
builder.Services.AddDbContext<bagsContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(IStartup));

builder.Services.AddScoped<IUserBL,UserBL>();
builder.Services.AddScoped<IuserDL, userDL>();

builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<ICategoryDL, CategoryDL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<IRatingDL, RatingDL>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
// Add services to the container.

builder.Services.AddControllers();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseErrorHandlingMiddleware();

//app.UseRatingMiddleware();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
//!!!!!!!!!!!!!!!!!!!!!!!!