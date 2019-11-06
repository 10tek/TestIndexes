using IndexTests.Models;
using System;

namespace IndexTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=A-305-11;Database=IndexTest;Trusted_Connection=True;";
            var random = new Random();
            using (var context = new TestContext(connectionString))
            {
                for (var i = 5000; i < 15000; i++)
                {
                    context.Photos.Add(new Photo
                    {
                        PhotographDateTime = DateTime.Now,
                        Longitude = random.NextDouble(),
                        Latitude = random.NextDouble(),
                        IsDeleted = false,
                        FileName = $"File#{i}",
                        Url = $"qwerty{random.Next(10000,100000)}",
                        PhoneModel = $"Xiaomi redmi {random.Next(2,10)}"
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
