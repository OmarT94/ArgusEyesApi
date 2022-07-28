using ArgusEyesApi.Data;
using ArgusEyesApi.Repositories;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KundenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ArgusKundenDaten")));
builder.Services.AddScoped<IkundenDatenRepository, KundenDatenRepository>();
builder.Services.AddScoped<IImageFileRepository, ImageFileRepository>();
builder.Services.AddScoped<IMetadatenRepository, MetadatenRepository>();
builder.Services.AddScoped<IPunktKoordinatenRepository, PunktKoordinatenRepository>();
builder.Services.AddDbContext<KundenDBContext>(opt =>
    opt.UseInMemoryDatabase("Metadaten"));

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
