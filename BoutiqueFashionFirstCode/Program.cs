using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.DBcontext;
using DAL.Reponsitories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Reponsitories.Implements;
using Microsoft.Extensions.DependencyInjection;
using BUS.Dtos;
using Microsoft.AspNetCore.OData;using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Org.BouncyCastle.Security;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BUS.Dtos;
using BUS.Profiles;

var builder = WebApplication.CreateBuilder(args);
var cross = "myCross";

builder.Services.AddCors(option =>
    option.AddPolicy(name: cross,
    policy =>
        policy.WithOrigins("*").WithMethods("GET", "PUT", "POST", "DELETE").AllowAnyMethod().AllowAnyHeader()
));


// Add services to the container.

// configuration the Odata for Client Driven Paging
builder.Services.AddControllers().AddOData(odt =>
    {
        odt.Count().Select().SetMaxTop(1000).OrderBy().Filter().Expand().AddRouteComponents("odata", GetEdmModel());
        odt.TimeZone=TimeZoneInfo.Utc;
    }
);



// nhận collection Dto được tham chiếu để cấu hình và phân trang.
static IEdmModel GetEdmModel() 
{
    var odataBuilder = new ODataConventionModelBuilder();

   // odataBuilder.ComplexType<ProductDetailsDto>();

    odataBuilder.EntityType<ProductDetailsDto>().HasKey(entity => new {entity.VariantId});
    odataBuilder.EntitySet<ProductDetailsDto>("ProductDetail");

    var getProductCollectionFunction = odataBuilder.EntityType<ProductDetailsDto>().Function("GetAllProductDetail").ReturnsCollectionFromEntitySet<ProductDetailsDto>("ProductDetail");

    return odataBuilder.GetEdmModel();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BoutiqueProfile));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IManageService, ManageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
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
// Use odata route debug, /$odata
app.UseODataRouteDebug();
// Add OData /$query middleware
app.UseODataQueryRequest();
// Add the OData Batch middleware to support OData $Batch
app.UseODataBatching();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
