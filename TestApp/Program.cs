using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobs;

namespace TestApp
{
	internal static class Program
	{
		private static void Main()
		{
			Console.WriteLine("Starting fetching data...");
			Console.WriteLine(new string('-', 20));

			var mainTask = RunAsync();
			mainTask.Wait(TimeSpan.FromMinutes(5));

			Console.WriteLine(new string('-', 20));
			Console.WriteLine("Exiting... Press any key to close...");
			Console.ReadKey();
		}

		private static async Task RunAsync()
		{
			var applicantsParser = new JobsParser(new JobsParserSettings(Category.Industry));
			var applicants = (await applicantsParser.ParseAsync()).ToArray();

			foreach (var applicant in applicants)
			{
				Console.WriteLine(applicant);
			}
		}
	}
}
