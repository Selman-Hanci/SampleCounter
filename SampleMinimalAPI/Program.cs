using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

Func<double, double> pow = Math.Sin;



app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

int Increaser(int number)
{
    return ++number;
}

List<int> numbers = new List<int> { 1, 2, 3, 12, 2, 45, 1, 555, 999999999, 3, 5 };

app.MapPost("/temperatureforecast", () =>
{
    NumberDelegate numberDelegate = Increaser;
    var temp = numberDelegate(1);
    var temp2 = numberDelegate.Invoke(1);

    var max = numbers.Max();
    var min = numbers.Min();
    var average = numbers.Average();

    TemperatureForeCast temperatureForeCast = new TemperatureForeCast((int)max);
    return temperatureForeCast;
});

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record TemperatureForeCast(int temperature)
{
}

public delegate int NumberDelegate(int no);
