using FreelanceProject.API.Util;
using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Helper;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;
using FreelanceProject.DAL.Repos.Mahmoud.Conditions;
using FreelanceProject.DAL.Repos.Mahmoud.Instructions;
using FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using FreelanceProject.DAL.Repos.Mona.Choices;
using FreelanceProject.DAL.Repos.Mona.Emergency;
using FreelanceProject.DAL.Repos.Mona.Questions;
using FreelanceProject.DAL.Repos.Mona.Users;

using JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddCors();
services.AddControllers();

// configure strongly typed settings object
services.AddScoped<IAuthService, AuthService>();
services.Configure<JWTc>(builder.Configuration.GetSection("JWT"));
services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MedicalContext>();
services.AddDbContext<MedicalContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
}

);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

#region ScopedServices

builder.Services.AddScoped<ICasesRepo, CaseRepo>();
builder.Services.AddScoped<IConditionRepo, ConditionRepo>();
builder.Services.AddScoped<ISubCaseRepo, SubCaseRepo>();
builder.Services.AddScoped<ISubYTLinks, SubYT>();
builder.Services.AddScoped<IinstructionRepo, InstructionRepo>();


builder.Services.AddScoped<IQuestionRepo,QuestionRepo>();
builder.Services.AddScoped<IChoiceRepo,ChoiceRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IEmergencyRepo, EmergencyRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

#endregion

#region Configuration
var ConnectionString = builder.Configuration.GetConnectionString("MedicalUrl");
builder.Services.AddDbContext<MedicalContext>( options => options.UseSqlServer(ConnectionString) );

builder.Services.Configure<ImageFilters>(builder.Configuration.GetSection("ImageFilters"));
   
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Add Authentication  should be before Authorize
app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
