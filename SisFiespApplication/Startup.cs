using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SisFiespApplication.Models;

namespace SisFiespApplication
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
			//string stringConexao = "Server=localhost;DataBase=sisfiesp;Uid=root;Pwd=123456";
			string stringConexao = "Server=mysql5036.site4now.net;DataBase=db_a70d3e_viniciu;Uid=a70d3e_viniciu;Pwd=sisfiesp123";
			services.AddDbContext<Contexto>(options =>
			options.UseMySQL(stringConexao));

			services.AddControllersWithViews();

			services.AddDistributedMemoryCache();

			services.AddWebEncoders(o => {
				o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
			});

			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseSession();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=Index}/{id?}");
			});
		}
	}
}
