using Domain;
using Service; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DepartmentService>();// Соединяем сервис DepartmentService с программой Апи
builder.Services.AddScoped<EmployeeService>();//Соединяем сервис EmployeeService с программой Апи
builder.Services.AddScoped<ManagerService>();//Соединяем сервис ManagerService с программой Апи

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
