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
			var devurl = "http://192.168.0.151:5656";

			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseUrls(url)
				.Build();
		}
	}
}
