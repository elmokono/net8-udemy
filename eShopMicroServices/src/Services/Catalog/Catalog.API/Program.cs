var builder = WebApplication.CreateBuilder(args);

// add services here..
builder.Services.AddCarter(); //registra todos los servicios de Carter
builder.Services.AddMediatR(config => {  //registra todos los servicios de MediatR en ESTE assembly
    config.RegisterServicesFromAssembly(typeof(Program).Assembly); 
});

var app = builder.Build();

// config http pipe here..
app.MapCarter(); //registra todas las clases ICarterModule

app.Run();
