var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGitHubPages", policy =>
    {
        policy.WithOrigins("https://dbaofd.github.io")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure for Render deployment - use PORT environment variable
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowGitHubPages");

app.MapPost("/convert-currency", (ConvertRequest request) =>
{
    try
    {
        var converter = new NumberConverter.NumberConverter();
        var result = converter.ConvertToCurrency(request.Number);
        return Results.Ok(new ConvertResponse(result));
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
})
.WithName("ConvertCurrency")
.WithOpenApi();

app.Run();

record ConvertRequest(string Number);
record ConvertResponse(string Words);
