using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace G07_Taijitan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (ApplicationDbContext context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    new GebruikerDataInitializer(context).InitializeData();
            //    var gebruikers = context.gebruikers.ToList();
            //    gebruikers.ForEach(t => Console.WriteLine(t.Voornaam));
            //    Console.WriteLine("Database created");
            //}
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
