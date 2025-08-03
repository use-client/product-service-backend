using ProductService.DapperRepositories;
using ProductService.Data;
using ProductService.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔌 Register DbConnectionFactory
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

// 🔌 Register UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Global error handler
app.UseGlobalExceptionMiddleware();

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
