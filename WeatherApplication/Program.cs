using System.Net.Http.Headers;
using WeatherApplication.Domain.DataAccessService;
using WeatherApplication.Domain.Options;
using WeatherApplication.Infrastructure;
using WeatherApplication.Infrastructure.DataAccessService;

var builder = WebApplication.CreateBuilder(args);
var applicationOptions = builder.Configuration.Get<ApplicationOptions>();

// Add services to the container.
builder.Services.AddServices();

builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
{
    client.BaseAddress = new System.Uri(builder.Configuration["WeatherProvider:Url"]);
    client.Timeout = TimeSpan.FromSeconds(builder.Configuration.GetValue("WeatherProvider:Timeout", 30));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.Configure<ApplicationOptions>(options => builder.Configuration.Bind(options));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", (context) => context
        .Response.WriteAsync("Service is running"));
});

app.Run();
