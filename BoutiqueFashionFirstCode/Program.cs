using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.DBcontext;
using DAL.Reponsitories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Reponsitories.Implements;

using Microsoft.Extensions.DependencyInjection;
using BUS.BusEntity;

var builder = WebApplication.CreateBuilder(args);
var cross = "myCross";

builder.Services.AddCors(option =>
    option.AddPolicy(name: cross,
    policy =>
        policy.WithOrigins("*").WithMethods("GET", "PUT", "POST", "DELETE").AllowAnyMethod().AllowAnyHeader()
));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IGenericRepository<user>, GenericRepository<user>>();
//builder.Services.AddScoped<IGenericRepository<Options>, GenericRepository<Options>>();
//builder.Services.AddScoped<IGenericRepository<OptionValues>, GenericRepository<OptionValues>>();
//builder.Services.AddScoped<IGenericRepository<ProductOptions>, GenericRepository<ProductOptions>>();
//builder.Services.AddScoped<IGenericRepository<Products>, GenericRepository<Products>>();
//builder.Services.AddScoped<IGenericRepository<ProductVariants>, GenericRepository<ProductVariants>>();
//builder.Services.AddScoped<IGenericRepository<VariantValues>, GenericRepository<VariantValues>>();
//builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddTransient<SendMailService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<SendMailService>();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cross);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
