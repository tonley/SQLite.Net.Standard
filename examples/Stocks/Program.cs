using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Path = System.IO.Path;
using Stocks;

namespace Stocks.CommandLine
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run();
        }


        void Run()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Stocks.db");

            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }

            Console.WriteLine("Creating database and valuation table...");

            var database = new Stocks.Database(dbPath);

            Console.WriteLine("Downloading data and inserting in to table...");

            database.UpdateStock("GE");

            Console.WriteLine("Getting data from database...");

            var data = database.GetData();

            foreach (var asd in data.Data)
            {
                Console.WriteLine($"Price: {asd["Price"]}");
            }


            Console.WriteLine("Done.");

            Console.Read();
        }
    }
}
