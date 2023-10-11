using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Configuration;
using AutoMapper;
using APITemplate;
using MainDBContext;

APITemplate.AssemblyConfigurationCaller.Setup();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ErrorHandlingFilter());
});

var mapperConfig = new MapperConfiguration(cfg =>
{
    //Handel all added mappers in ConfigInit.cs files.
    Configuration.ConfigMappers.Setup(cfg, cfg.GetType());
});

var mapper = new Configuration.ConfigWrapperMapper(mapperConfig);
builder.Services.AddSingleton<Configuration.IMapper>(mapper);

//Handel all added database contexts and servies in configInit.cs files.

Configuration.ConfigDBContext.Setup(builder.Services, typeof(EntityFrameworkServiceCollectionExtensions));
Configuration.ConfigServices.Setup(builder.Services, typeof(ServiceCollectionServiceExtensions));


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
