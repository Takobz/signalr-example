using SignalRExample.Data;
using SignalRExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddTransient<ISignalRDbContext, SignalRDbContext>();
builder.Services.AddDbContext<SignalRDbContext>();

builder.Services.AddCors(options => {
    options.AddPolicy("freeForAll", builder => 
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("freeForAll");

app.UseAuthorization();

app.MapControllers();
app.MapHub<DatabaseHub>("/database-hub");

app.Run();
