using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OnePayAPI.IServices;
using OnePayAPI.Models;
using OnePayAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShivaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMerchantAccountService, MerchantAccountService>();
builder.Services.AddScoped<ISignLogServices, SignLogServices>();
builder.Services.AddScoped<IProfileService, ProfileService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutter",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutter",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//  Make Swagger open by default
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();
app.UseCors("AllowFlutter");
app.UseAuthorization();

app.MapControllers();

app.Run();
