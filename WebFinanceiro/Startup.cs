using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFinanceiro.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Generics;
using Infra.Repositorio.Genericos;
using Domain.Interfaces.IDespesa;
using Applications.Interfaces;
using Domain.Interfaces.ICategoria;
using Infra.Repositorio;
using Applications.App;
using WebFinanceiro.Models;
using Domain.Servicos;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.ISugestao;
using Domain.Interfaces.ICompra;
using Microsoft.Extensions.Hosting;

namespace WebFinanceiro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
              //.AddDefaultUI(UIFramework.Bootstrap4) /////////////////
              .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // CONFIGURAÇÕES DO IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            ///////////////////////////////////////////////////////

            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGenerico<>));
            services.AddSingleton<InterfaceCategoria, RepositorioCategoria>();
            services.AddSingleton<InterfaceDespesa, RepositorioDespesa>();
            services.AddSingleton<InterfaceSistemaFinanceiro, RepositorioSistemaFinanceiro>();
            services.AddSingleton<InterfaceUsuarioSistemaFinanceiro, RepositorioUsuarioSistemaFinanceiro>();
            services.AddSingleton<InterfaceSugestao, RepositorioSugestao>();
            services.AddSingleton<InterfaceCompra, RepositorioCompra>();
            services.AddSingleton<InterfaceItemCompra, RepositorioItemCompra>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<InterfaceAppCategoria, AppCategoria>();
            services.AddSingleton<InterfaceAppDespesa, AppDespesa>();
            services.AddSingleton<InterfaceAppSistemaFinanceiro, AppSistemaFinanceiro>();
            services.AddSingleton<InterfaceAppUsuarioSistemaFinanceiro, AppUsuarioSistemaFinanceiro>();
            services.AddSingleton<InterfaceAppSugestao, AppSugestao>();
            services.AddSingleton<InterfaceAppCompra, AppCompra>();
            services.AddSingleton<InterfaceAppItemCompra, AppItemCompra>();

            services.AddDbContext<WebFinanceiroContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebFinanceiroContext")));

            // SERVIÇO DOMINIO
            services.AddSingleton<IDespesaServico, DespesaServico>();
            services.AddSingleton<ISistemaFinanceiroServico, SistemaFinanceiroServico>();
            services.AddSingleton<IUsuarioSistemaFinanceiroServico, UsuarioSistemaFinanceiroServico>();
            services.AddSingleton<ICategoriaServico, CategoriaServico>();
            services.AddSingleton<ICompraServico, CompraServico>();
            services.AddSingleton<IItemCompraServico, ItemCompraServico>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage(); 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}"
                   );
               endpoints.MapRazorPages();
           });
        }
    }
}
