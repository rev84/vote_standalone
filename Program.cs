using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:65023/")
                .UseStartup<Startup>();

    }

}
