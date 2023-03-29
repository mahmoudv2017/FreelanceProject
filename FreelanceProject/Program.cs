using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;
using FreelanceProject.DAL.Repos.Mona.Choices;
using FreelanceProject.DAL.Repos.Mona.Emergency;
using FreelanceProject.DAL.Repos.Mona.Questions;
using FreelanceProject.DAL.Repos.Mona.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region ScopedServices

builder.Services.AddScoped<ICasesRepo, CaseRepo>();
builder.Services.AddScoped<IQuestionRepo,QuestionRepo>();
builder.Services.AddScoped<IChoiceRepo,ChoiceRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IEmergencyRepo, EmergencyRepo>();

#endregion

#region Configuration
var ConnectionString = builder.Configuration.GetConnectionString("MedicalUrl");
builder.Services.AddDbContext<MedicalContext>( options => options.UseSqlServer(ConnectionString) );
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

app.MapControllers();

app.Run();
