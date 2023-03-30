using FreelanceProject.API.Util;
using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;
using FreelanceProject.DAL.Repos.Mahmoud.Conditions;
using FreelanceProject.DAL.Repos.Mahmoud.Instructions;
using FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using FreelanceProject.DAL.Repos.Mona.Choices;
using FreelanceProject.DAL.Repos.Mona.Questions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
