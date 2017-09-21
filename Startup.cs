using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SeminarieEnquete
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			MongoConnection.MongoConnection.InitializeConnection("mongodb://192.168.0.151:27017", "seminarie_enquete");
			app.UseMvc();
			app.UseStaticFiles();
		}
	}
}
