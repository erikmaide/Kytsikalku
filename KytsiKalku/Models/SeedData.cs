using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KytsiKalku.Data;
using System;
using System.Linq;

namespace KytsiKalku.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KytsiKalkuFuelContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<KytsiKalkuFuelContext>>()))
            {
                // Look for any movies.
                if (context.FuelData.Any())
                {
                    return;   // DB has been seeded
                }

                context.FuelData.AddRange(
                    new FuelData
                    {
                        TripName = "Tallinn-Tartu",
                        DriveDate = DateTime.Parse("2020-3-10"),
                        TripStart = 102230,
                        TripEnd = 102411
                    },
                                        new FuelData
                                        {
                                            TripName = "Tartu-Tallinn",
                                            DriveDate = DateTime.Parse("2020-4-10"),
                                            TripStart = 102411,
                                            TripEnd = 102592
                                        }

                );
                context.SaveChanges();
            }
        }
    }
}