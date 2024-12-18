using API.Middelwares;
using ExternalSerivces.ServicesConfiguration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonitorWorker;
using Persistance.DataBaseConfig;
using Persistance.Entities;
using Persistance.Interfaces;
using Persistance.Repositories;
using Persistance.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExternalServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SchoolDatabaseSettings>(builder.Configuration.GetSection("SchoolDatabaseSettings"));
builder.Services.AddScoped<IStudentService,StudentRepository>();
builder.Services.AddScoped<ICourseService,CourseRepository>();
builder.Services.AddSingleton<IAdminstrationService,AdminstrationService>();

builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var connectionString = builder.Configuration.GetSection("SchoolDatabaseSettings:ConnectionString").Value;

    return new MongoClient(connectionString);   
});

builder.Services.AddScoped<MongoDbContext>(serviceProvider => 
{ 
   var client = serviceProvider.GetRequiredService<IMongoClient>();
   var schooldbSetting = serviceProvider.GetService<IOptions<SchoolDatabaseSettings>>()?.Value;
   var database = client.GetDatabase(schooldbSetting?.DatabaseName);
    

    return new MongoDbContext(database);    
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<OnNewStudentAddedCommand>());

//hosting
/*builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
    options.ServicesStopConcurrently = true;
});*/

//builder.Services.AddSingleton<IMongoDbChangeStreamService,MongoDbChangeStreamService>();
//builder.Services.AddHostedService<DatabseEventStreamWorker>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.ConfigureCustomExceptionMiddelware();

app.UseHttpsRedirection();

app.UseAuthorization();

//custom middelware

app.MapControllers();

app.Run();
