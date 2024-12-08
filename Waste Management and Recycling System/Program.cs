using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Middlewares;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

//Add DbContext
builder.Services.AddDbContext<WasteManagementandRecyclingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add repositories
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<ICollectionRepo,CollectionRepo>();
builder.Services.AddScoped<IRecyclingPlantRepo, RecyclingPlantRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddScoped<IResourceRepo, ResourceRepo>();
builder.Services.AddScoped<ITrainingRepo, TrainingRepo>();
builder.Services.AddScoped<IEventRepo, EventRepo>();
builder.Services.AddScoped<IIncentiveRepo, IncentiveRepo>();
builder.Services.AddScoped<IHazardousWasteRepo, HazardousWasteRepo>();
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IRecyclingPlantService, RecyclingPlantService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IIncentiveService, IncentiveService>();
builder.Services.AddScoped<IHazardousWasteService, HazardousWasteService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Authentication
var jwtval = builder.Configuration.GetSection("JWT");
var key = Encoding.UTF8.GetBytes(jwtval["Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(i =>
{
    i.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorizationMiddleware();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
