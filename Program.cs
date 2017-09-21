using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SeminarieEnquete
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseUrls("http://192.168.0.151:5656")
				.Build();
	}
}
