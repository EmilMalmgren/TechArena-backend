using TechArena.MongoDb;
using TechArena.MongoDb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MongoDB context and repositories
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<CommunityPantryRepository>();
builder.Services.AddScoped<LocationRepository>();
builder.Services.AddScoped<FridgeItemRepository>();
builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:8080")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowReactApp");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


