using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SeminarieEnquete
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			var url = $"http://*:{Environment.GetEnvironmentVariable("PORT")}/";

			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseUrls(url)
				.Build();
		}
	}
}
