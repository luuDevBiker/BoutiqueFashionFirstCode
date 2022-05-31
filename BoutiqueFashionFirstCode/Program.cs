using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.DBcontext;
using DAL.Reponsitories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Reponsitories.Implements;

var builder = WebApplication.CreateBuilder(args);
var cross = "myCross";
// Add services to the container.
builder.Services.AddCors(option =>
    option.AddPolicy(name: cross,
        policy =>
            policy.WithOrigins("https://localhost:3000/")
            .WithMethods("POST", "PUT", "DELETE", "GET")
            .AllowAnyMethod()
            .AllowAnyHeader()
));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<user>, GenericRepository<user>>();
builder.Services.AddScoped<IGenericRepository<Options>, GenericRepository<Options>>();
builder.Services.AddScoped<IGenericRepository<OptionValues>, GenericRepository<OptionValues>>();
builder.Services.AddScoped<IGenericRepository<ProductOptions>, GenericRepository<ProductOptions>>();
builder.Services.AddScoped<IGenericRepository<Products>, GenericRepository<Products>>();
builder.Services.AddScoped<IGenericRepository<ProductVariants>, GenericRepository<ProductVariants>>();
builder.Services.AddScoped<IGenericRepository<VariantValues>, GenericRepository<VariantValues>>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<SendMailService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<SendMailService>();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cross);
app.UseAuthorization();

app.MapControllers();

app.Run();
