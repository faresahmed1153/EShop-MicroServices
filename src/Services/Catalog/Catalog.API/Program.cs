using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter(
    new DependencyContextAssemblyCatalog(assemblies: assembly)
);


builder.Services.AddMediatR(config => {

    config.RegisterServicesFromAssembly(assembly);

    config.AddOpenBehavior(typeof(BuildingBlocks.Behaviors.ValidationBehavior<,>));
});


builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMarten(configure=>
{
    configure.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseExceptionHandler(options => { });
app.MapCarter();
app.Run();