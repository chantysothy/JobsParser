using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Jobs;

namespace TestApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var data = new[]
            {
                "23 года и 1 месяц",
                "1 год и 9 месяцев",
                "20 лет и 2 месяца",
                "19 лет ",
                "1 месяц",
            };
            foreach (var s in data)
            {
                
            }

            //RunAsync();
            Console.WriteLine("Exiting... Press any key to close...");
            Console.ReadKey();
        }

        private static async void RunAsync()
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