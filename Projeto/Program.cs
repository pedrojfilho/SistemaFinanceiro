using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Exibir os erros detalhados no desenvolvimento
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Página genérica de erro em produção
}

app.UseHttpsRedirection();  // Redirecionar HTTP para HTTPS
app.UseRouting();  // Habilitar o roteamento

app.MapControllers();  // Mapeia os controllers para as rotas

app.Run();  
