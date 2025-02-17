using sisdigitalizacion.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlConfiguracion = new MysqlConfiguracion(builder.Configuration.GetConnectionString("MysqlConnection"));
builder.Services.AddSingleton(mysqlConfiguracion);

builder.Services.AddScoped<IsisdigitalizacionRepository, PlanificacionRepository>();
builder.Services.AddScoped<IsisoficioDireccionCarreraRepository, OficioDireccionCarreraRepository>();
builder.Services.AddScoped<IsisactividadesPracticas, ActividadesPracticasRepository>();
builder.Services.AddScoped<IsiscronoActividades, CronoActividadesRepository>();
builder.Services.AddScoped<IsisactaCompromiso, ActaCompromisoRepository>();
builder.Services.AddScoped<IsisCumplimientoHorasRepository, CumplimientoHorasRepository>();
builder.Services.AddScoped<IsisEvaluacionPracticaRepository, EvaluacionPracticaRepositorycs>();
builder.Services.AddScoped<IsisEvaluacionFinalCertificadoRepository, EvaluacionFinalCertificadoRepository>();
builder.Services.AddScoped<IsisInformeFinal, InformeFinalRepository>();
builder.Services.AddScoped<IsisInformeTutorias, InformeTutorialRepository>();
builder.Services.AddScoped<IsisMatriculacionRepository, MatriculacionRepository>();
builder.Services.AddScoped<IsisInformeActividadesPracticas, InformeActividadesPracticasRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "widthoutCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable Swagger in development only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("widthoutCors");

app.UseAuthorization();

// Configurar la aplicación para escuchar en todas las interfaces
//app.Urls.Add("http://0.0.0.0:5000");

app.MapControllers();

app.Run();
