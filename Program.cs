using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using vote_standalone.Models.Sqlite3;

namespace vote_standalone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sqlite3 sqlite = new Sqlite3();
            sqlite.BeginTransaction();
            User.Create("Revin", "a", sqlite);
            sqlite.Commit();

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:65023/");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
