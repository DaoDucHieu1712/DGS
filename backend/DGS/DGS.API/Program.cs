using DGS.BusinessObjects;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.impls;
using DGS.DataAccess.interfaces;
using DGS.Repository;
using DGS.Repository.impls;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region database

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
         o => o.MigrationsAssembly(typeof(ApplicationDbContext).FullName));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
#endregion

#region dao

builder.Services.AddTransient(typeof(IDAO<,>), typeof(EntityDAO<,>));

builder.Services.AddTransient<IProductDAO, ProductDAO>();
builder.Services.AddTransient<ICategoryDAO, CategoryDAO>();
builder.Services.AddTransient<IOrderDAO, OrderDAO>();
builder.Services.AddTransient<IOrderDetailDAO, OrderDetailDAO>();

#endregion

#region repository

builder.Services.AddTransient<IProductRepository, ProductRepository>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
