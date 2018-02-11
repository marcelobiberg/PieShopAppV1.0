using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PieApp.Models;

namespace PieApp
{
    public class Startup
    {
        //logic for connectionString
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //define a connectionString
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //injeção de dependência, uma instância do IPieRepository eh solicitada, sempre uma nova instância 
            services.AddTransient<IPieRepository, PieRepository>();
            //injeção de dependência, uma instância do IFeedbackRepository 
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            
            //adiciona o framework mvc 
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //define culture pt-BR para decimal, monetário e porcentagem
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";//define R$ como default para monetário
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //usar apenas para criação do projeto, pois serve apenas para o Dev
            //enviao ao Dev uma page com exception detalhadas para ajudar no desenvolvimento
            app.UseDeveloperExceptionPage();

            //Por padrão, o aplicativo não fornece uma página de código de status detalhadas para códigos de, 
            //status HTTP como 500 (erro interno do servidor) ou 404 (não encontrado).
            app.UseStatusCodePages();

            //procura por static files em wwwroot, static files = image, css, js an so on
            app.UseStaticFiles();

            //deve ser antes do useMvc, estudar isso
            app.UseAuthentication(); 

            //usa rota default implementada por mim, controller=Home, action=Index, id=nullable
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
