using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using TreasuryChallenge.src.Extensions;
using TreasuryChallenge.src.Services;

namespace TreasuryChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var generateCodesService = serviceProvider.GetService<IGenerateCodesService>();

            try
            {
                Console.WriteLine("Please enter the number without dots or commas of codes required for marketing campaigns and press enter.");

                int numberOfLines;
                while (true)
                {
                    var input = Console.ReadLine();

                    var success = int.TryParse(input, out int number);

                    if (success && number > 0)
                    {
                        numberOfLines = number;
                        break;
                    }

                    Console.WriteLine("Invalid data. Please insert a number greater than zero.");
                }

                var timeSpent = Stopwatch.StartNew();

                var codes = generateCodesService.GenerateCodes(numberOfLines);

                codes.ExportToTextFile("ResultFileText.txt");

                timeSpent.Stop();

                Console.WriteLine($"Time spent generating the codes: {timeSpent.ElapsedMilliseconds} milliseconds.");
            }
            catch
            {
                Console.WriteLine("Something went wrong, please close the console and try again.");
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGenerateCodesService, GenerateCodesService>();
        }
    }
}