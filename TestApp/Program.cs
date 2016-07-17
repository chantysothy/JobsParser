using System;
using System.Linq;
using System.Threading.Tasks;
using Jobs;
using Jobs.Models;
using Jobs.Parsers;

namespace TestApp
{
	internal static class Program
	{
		private static void Main()
		{
			Console.WriteLine("Starting fetching data...");
			Console.WriteLine(new string('=', 70));
			Console.WriteLine();

			var mainTask = RunAsync();
			mainTask.Wait(TimeSpan.FromMinutes(5));

			Console.WriteLine();
			Console.WriteLine(new string('=', 70));
			Console.WriteLine("Exiting... Press any key to close...");
			Console.ReadKey();
		}

		private static async Task RunAsync()
		{
			var applicantsParser = new JobsParser(new JobsParserSettings(Category.Industry, new DefaultHtmlDataProvider()));
			var applicants = (await applicantsParser.ParseAsync()).ToArray();

			foreach (var applicant in applicants)
			{
				Console.WriteLine(applicant);
			}
		}
	}
}
