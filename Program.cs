using IndexTests.Models;
using System;
using System.Linq;

namespace IndexTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=A-305-11;Database=IndexTest;Trusted_Connection=True;";
            using (var context = new TestContext(connectionString))
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //FillTablePhoto(context);
                var photos = context.Photos.Where(x=> x.FileName.Contains("123")).ToList();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs / 1000.0);
                if (photos.Count == 0)
                {
                    Console.WriteLine("Uncorrect");
                }
                else
                {
                    Console.Write("Correct, Count: ");
                    Console.WriteLine(photos.Count);
                }
            }
        }

        public static void FillTablePhoto(TestContext context)
        {
            var random = new Random();
            for (var i = 500000; i < 1000000; i++)
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
