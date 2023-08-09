using Microsoft.AspNetCore.Authentication;
using TudoHorroroso.Model;
using TudoHorroroso.Repositories;
using Security.PasswordHasher;
using TudoHorroroso.Services;
using Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
        

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

builder.Services.Configure<RecipeDatabaseSettings>(
    builder.Configuration.GetSection("RecipeDataBase"));

builder.Services.AddSingleton<RecipeService>();

builder.Services.AddTransient<IRepository<Recipe>, RecipeRepository>();

builder.Services.AddTransient<TudoHorrorosoContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPasswordHasher, BasicPasswordHasher>();

builder.Services.AddTransient<IPasswordProvider>(p =>
{
    return new PasswordProvider("fedaf7d8863b48e197b9287d492b708e");
});
builder.Services.AddTransient<IJwtService, JwtService>();


var app = builder.Build();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

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
