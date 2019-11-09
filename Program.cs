using IndexTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = "Server=DESKTOP-TALUG4B\\SQLEXPRESS;Database=DbWithIndex;Trusted_Connection=True;";
            var connectionString = "Host=localhost;Port=5432;Database=IndexDb;Username=postgres;Password=postgres";
            using (var context = new TestContext(connectionString))
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //FillTablePhoto(context);
                var photos = new List<Photo>();
                for (int i = 0; i < 100; i++)
                {
                    photos = Query(context);
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.Write(elapsedMs / 1000.0);
                if (photos.Count == 0)
                {
                    Console.WriteLine("seconds\nUncorrect 100 queries");
                }
                else
                {
                    Console.Write($"seconds\nCorrect, 100 queries\nQuery result count: {photos.Count}");
                }
            }
        }

        public static List<Photo> Query(TestContext context)
        {
            return context.Photos.Where(x => x.Latitude == 0.7278786197900207 && x.Longitude == 0.3932823172739159).ToList();
        }

        public static void FillTablePhoto(TestContext context)
        {
            var random = new Random();
            for (var i = 0; i < 1000000; i++)
            {
                context.Photos.Add(new Photo
                {
                    PhotographDateTime = DateTime.Now,
                    Longitude = random.NextDouble(),
                    Latitude = random.NextDouble(),
                    IsDeleted = false,
                    FileName = $"File#{i}",
                    Url = $"qwerty{random.Next(10000, 100000)}",
                    PhoneModel = $"Xiaomi redmi {random.Next(2, 10)}"
                });
            }
            context.SaveChanges();
        }

    }
}
