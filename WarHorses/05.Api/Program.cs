using _02.Data.FirebaseRepository;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

// Obtenha o caminho absoluto do diretório atual do projeto
string basePath = AppDomain.CurrentDomain.BaseDirectory;
string configPath = Path.Combine(basePath, "Configs", "warhorses-teste-863edc237bc5.json");

builder.Services.AddSingleton<FirestoreDb>(provider =>
  {  
      var app = FirebaseApp.Create(new AppOptions
      {
          Credential = GoogleCredential.FromFile(configPath),
          ProjectId = "warhorses-teste",
      });

      return FirestoreDb.Create("warhorses-teste");
  });

builder.Services.AddScoped<ITesteRepoRepository, TesteRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();

var app = builder.Build();

// Configure o pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    Console.WriteLine("Ambiente de Desenvolvimento: Logs detalhados habilitados.");
}
else
{
    app.UseExceptionHandler("/Error");
    Console.WriteLine("Ambiente de Produção: Logs simplificados.");
}

// Configura��o do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty; // Deixando acess�vel na raiz do documento
});

// Middleware padr�o
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)); // Permite qualquer origem 
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Aplica��o configurada. Pronta para receber requisi��es!");
app.Run();
