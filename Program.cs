var builder = WebApplication.CreateBuilder(args);

//Configuração Swagger no builder
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração banco MySQL
builder.Services.AddDbContext<BancoDeDados>();

//Configuração CORs
builder.Services.AddCors();

var app = builder.Build();

//Configuração Swagger no app
app.UseSwagger();
app.UseSwaggerUI();

//  http://localhost:xxxx/swagger/index.html

app.MapGet("/", () => "App de Nutricao com API");

//Configuração CORs
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);


//APIs
app.MapAvaliacoesFisicaApi();
app.MapDietasApi();
app.MapNutrionistasApi();
app.MapPersonaisApi();
app.MapPlanosAlimentaresApi();
app.MapTreinosApi();
app.MapUsuariosApi();

app.Run();
