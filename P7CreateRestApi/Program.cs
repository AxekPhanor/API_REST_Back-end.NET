using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "PostTrades.Api", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
        In = ParameterLocation.Header,
        Description = "Entrer Bearer suivi de votre token pour avoir l'authorisation",
        Scheme = "Bearer",
        Name = "Authorization",
        BearerFormat = "JWT",
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<LocalDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireAuthenticatedUser();
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    });

    options.AddPolicy("User", policy =>
    {
        policy.RequireRole("User", "Admin");
        policy.RequireAuthenticatedUser();
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    });
});

var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwt["SecretKey"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

builder.Services.AddScoped<ICurvePointRepository, CurvePointRepository>();
builder.Services.AddScoped<ICurvePointService, CurvePointService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IRuleNameRepository, RuleNameRepository>();
builder.Services.AddScoped<IRuleNameService, RuleNameService>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<ITradeService, TradeService>();
builder.Services.AddScoped<IBidListRepository, BidListRepository>();
builder.Services.AddScoped<IBidListService, BidListService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var dbcontext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
        dbcontext.Database.EnsureCreated();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Creation des r�les 
using (var scope = app.Services.CreateScope())
{
    using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
    }
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
