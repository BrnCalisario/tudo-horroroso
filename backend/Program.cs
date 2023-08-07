using TudoHorroroso.Model;
using TudoHorroroso.Repositories;
using Security.PasswordHasher;
using TudoHorroroso.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RecipeDatabaseSettings>(
    builder.Configuration.GetSection("RecipeDataBase"));

builder.Services.AddSingleton<RecipeService>();

builder.Services.AddTransient<IRepository<Recipe>, RecipeRepository>();

builder.Services.AddTransient<TudoHorrorosoContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPasswordHasher, BasicPasswordHasher>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
    policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors();

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
