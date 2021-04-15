using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace MovieShop.MVC {
    public class Program {
        public static void Main(string[] args) {
            //https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/ for future reference
            //for emailing through serilog
            //CreateHostBuilder(args).Build().Run();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e) {
                Log.Fatal(e, "Application start-up failed");
            }
            finally { //runs after control leaves try statement
                Log.CloseAndFlush();
            }
        }
        


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
