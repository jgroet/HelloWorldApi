using System;
using System.IO;
using ConsoleApplication.Writer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace ConsoleApplication
{
	class Program
	{
		private static ServiceProvider _serviceProvider;

		static void Main(string[] args)
		{
			ConfigureServices();

			var client = new RestClient("https://localhost:44315/");
			var request = new RestRequest("api/helloworld");

			var response = client.Execute<string>(request);

			_serviceProvider.GetService<IWriter>().Write(response.Data);

			Console.WriteLine("\nPress any key to exit!");
			Console.ReadKey();
		}

		static void ConfigureServices()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true);

			var configuration = builder.Build();
			var serviceCollection = new ServiceCollection();

			if (configuration["writerType"] == "console")
			{
				serviceCollection.AddSingleton<IWriter, ConsoleWriter>();
			}

			_serviceProvider = serviceCollection.BuildServiceProvider();
		}
	}
}
