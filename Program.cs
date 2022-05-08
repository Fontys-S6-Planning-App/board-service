using board_service.DBContexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// set cors
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://planning-app.marktempelman.duckdns.org")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// set connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = builder.Configuration["Jwt:Authority"];
    o.Audience = builder.Configuration["Jwt:Audience"];
    o.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = c =>
        {
            if (!c.Response.HasStarted)
            {
                c.NoResult();
                c.Response.StatusCode = 500;
                c.Response.ContentType = "text/plain";
                return c.Response.WriteAsync("An error occured processing your authentication.");
            }
            else
            {
                return c.Response.WriteAsync(string.Empty);
            }
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(name: "board", pattern: "board/{controller=Board}/{action=Index}/{id?}");

app.Run();