// See https://aka.ms/new-console-template for more information
using TaskerProject.Business.Services;
using TaskerProject.Business.Services.Interfaces;
using TaskerProject.Data.Gateways;
using TaskerProject.Data.Gateways.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskerProject.Main.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//My dependencies;(deendency injection
builder.Services.AddScoped<ITaskerService, TaskerService>();
builder.Services.AddScoped<ITaskerGateway, TaskerGateway>();

//builder.Services.AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<VerificationCodeRequestValidator>());


//builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

ConfigureServices.AddConfigDependencies(builder.Services, builder.Configuration);

ConfigureServices.AddServiceDependencies(builder.Services);
ConfigureServices.AddGatewayDependencies(builder.Services, builder.Configuration);
ConfigureServices.AddAPIClientDependencies(builder.Services);
//ConfigureServices.AddValidatorDependencies(builder.Services);

ConfigureServices.AddAutoMapperProfiles(builder.Services);

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .WriteTo.File("logs/first_log.txt", rollingInterval: RollingInterval.Day)
  .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();

