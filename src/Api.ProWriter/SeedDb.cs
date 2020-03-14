using Data.ProWriter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ProWriter
{
    static public class SeedDb
    {
        static public void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Seed users
                if (context.Users.Any() == false)
                {
                    context.Users.AddRange(SeedData.GetUsers());
                }


                context.SaveChanges();
            }
        }
    }
}
