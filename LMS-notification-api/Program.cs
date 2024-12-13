using DAL.NotificationDbContext;
using DAL.Repositories;
using DotNetEnv;
using Logic.IRepositories;
using Logic.IServices;
using Logic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Env.Load();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(corsPolicyBuilder =>
	{
		corsPolicyBuilder.WithOrigins(Env.GetString("FRONT_END_URL"))
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials()
			.SetIsOriginAllowed(_ => true);
	});
});

var connectionString =
	$"Server={Env.GetString("DB_HOST")};Database={Env.GetString("DB_NAME")};User Id={Env.GetString("DB_USER")};Password={Env.GetString("DB_PASSWORD")};";

builder.Services.AddDbContext<NotificationDbContext>(options =>
	options.UseMySql(
		builder.Configuration.GetConnectionString(connectionString),
		new MySqlServerVersion(new Version(Env.GetInt("SQL_MAJOR"), Env.GetInt("SQL_MINOR"), Env.GetInt("SQL_BUILD")))
	)
);

//!TODO auth


builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
