using API.Middelwares;
using ExternalSerivces.ServicesConfiguration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonitorWorker;
using Persistance.DataBaseConfig;
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

/*builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
    options.ServicesStopConcurrently = true;
});*/

//builder.Services.AddSingleton<IMongoDbChangeStreamService,MongoDbChangeStreamService>();
//builder.Services.AddHostedService<DatabseEventStreamWorker>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddelware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWhen(context => context.Request.Path == "/api/student/add", builder =>
{
    builder.Use(async(context,next) =>
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var administrationService = scope.ServiceProvider.GetRequiredService<IAdminstrationService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>(); 
      

      
       administrationService.SubscribeToNewStudentEvent(studentService);
        
        await next();

       administrationService?.UnsubscribeToNewStudentEvent(studentService);
    });
});
//custom middelware

app.MapControllers();

app.Run();
