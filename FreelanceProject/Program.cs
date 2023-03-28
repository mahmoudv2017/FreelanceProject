using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region ScopedServices

builder.Services.AddScoped<ICasesRepo, CaseRepo>();

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
