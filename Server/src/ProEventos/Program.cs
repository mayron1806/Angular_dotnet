using ProEventos.Persistence;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Context;
using ProEventos.Application.Interfaces;
using ProEventos.Application;
using ProEventos.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// adiciona o contexto 'proeventoscontext' 
// define as opcoes que serao injetadas no 'proeventoscontext'
builder.Services.AddDbContext<ProEventosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services
.AddControllers()
.AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// adiciona injecao de dependencia 
// sempre que um "IEventoService" for requisitado, ele vai injetar "EventoService"
builder.Services.AddScoped<IEventoService, EventoService>();

// sempre que um "IGenericoPersistence" for requisitado, ele vai injetar "GenericoPersistence"
builder.Services.AddScoped<IGenericoPersistence, GenericoPersistence>();

// sempre que um "IEventoPersistence" for requisitado, ele vai injetar "EventoPersistence"
builder.Services.AddScoped<IEventoPersistence, EventoPersistence>();

// adiciona o cors a API
builder.Services.AddCors();

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
// define as propriedades do cors
// allowAnyOrigin = permite que todas origens acessem a API
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();

app.Run();
