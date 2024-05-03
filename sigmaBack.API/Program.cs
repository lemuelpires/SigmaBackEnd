using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using sigmaBack.Application.Services;
using sigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Repositories;
using SigmaBack.Application.Services;
using SigmaBack.Domain.Interfaces;
using SigmaBack.Infra.Data.Repositories;
using SigmaBack.Infrastructure.Repositories;

namespace sigmaBack.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SigmaBack v1");
            });
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Registro do contexto do banco de dados
            services.AddDbContext<sigmaBack.Infra.Data.Contexts.SigmaDbContext>(options =>
               options.UseSqlServer(GetConnectionString()));

            // Registro do serviço AvaliacaoService
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
            services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProdutoRepository,ProdutoRepository>();
            services.AddScoped<IProdutoService,ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IItemCarrinhoService, ItemCarrinhoService>();
            services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>(); 
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
                   

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "sigmaBack", Version = "v1" });
            });
        }

        private static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            // Obtenha a conexão padrão ou forneça uma string padrão se a chave não for encontrada
            return config.GetConnectionString("DefaultConnection") ?? "DefaultConnectionString";
        }

    }
}
