using Microsoft.EntityFrameworkCore;
using OTF_System.Data;
using OTF_System.Services;
using Sachintha.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddDbContext<dbcontext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IPoliceOfficerService, PoliceOfficerService>();
builder.Services.AddScoped<IFineService, FineService>(); //  Register FineService
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
