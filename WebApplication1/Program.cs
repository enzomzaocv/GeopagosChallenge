using TennisTournament.Core;
using TennisTournament.DataBaseContext;
using TennisTournament.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TennisTournamentDbContext>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ISkillTypeRepository, SkillTypeRepository>();
builder.Services.AddScoped<ISkillTypeCore, SkillTypeCore>();
builder.Services.AddScoped<ITournamentCore, TournamentCore>();
builder.Services.AddScoped<IPlayerCore, PlayerCore>();
builder.Services.AddControllers();
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

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();