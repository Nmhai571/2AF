using _2FA.Entities;
using _2FA.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SMSSetting>(builder.Configuration.GetSection("SMSSetting"));
builder.Services.AddDbContext<SMSDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("2FAConnection")));
builder.Services.AddTransient<ISMSService, SMSService>();

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
