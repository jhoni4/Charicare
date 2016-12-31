using Charicare2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products.
                if (context.DonateType.Any())
                {
                    return;   // DB has been seeded
                }

                // 1  DonateTYPES
                var DonateTypes = new DonateType[]
                {
                  new DonateType {
                      Name = "Clothes",
                      Description = "This Catagory includes any type of clothes like pijamas, sheets, blankets, shoes.... "
                  },
                  new DonateType {
                      Name = "Financial/Money",
                      Description = "This Category includes........"
                  },
                  new DonateType {
                      Name = "Goods",
                      Description = "This Category includes........"
                  },
                  new DonateType {
                      Name = "Medical Supplies",
                      Description = "This Category includes........"
                  }
                };

                foreach (DonateType i in DonateTypes)
                {
                    context.DonateType.Add(i);
                }
                context.SaveChanges();

                // 2  Donates.  - Seeding the database.

                var Donates = new Donate[]
                {
                  new Donate {
                      Name = "Clothes",
                      Note = "contact me in person",
                      CustomerId = 3,
                      DonateTypeId = 1,
                      Value = 160
                  },
                  new Donate {
                      Name = "Pillow",
                      Note = "contact me in person",
                      CustomerId = 2,
                      DonateTypeId = 1,
                      Value = 120
                  },
                  new Donate {
                      Name = "Blankets",
                      Note = "contact me in person",
                      CustomerId = 4,
                      DonateTypeId = 1,
                      Value = 150
                  },
                  new Donate {
                      Name = "Vitamine B12",
                      Note = "contact me in person",
                      CustomerId = 1,
                      DonateTypeId = 4,
                      Value = 110
                  },
                  new Donate {
                      Name = "Advil",
                      Note = "contact me in person",
                      CustomerId = 2,
                      DonateTypeId = 4,
                      Value = 120
                  },
                  new Donate {
                      Name = "Sanitaizer",
                      Note = "contact me in person",
                      CustomerId = 4,
                      DonateTypeId = 4,
                      Value = 210
                  },
                  new Donate {
                      Name = "Cash",
                      Note = "contact me in person",
                      CustomerId = 2,
                      DonateTypeId = 2,
                      Value = 200
                  },
                  new Donate {
                      Name = "Cash",
                      Note = "contact me in person",
                      CustomerId = 3,
                      DonateTypeId = 2,
                      Value = 100
                  },
                  new Donate {
                      Name = "Cash",
                      Note = "contact me in person",
                      CustomerId = 2,
                      DonateTypeId = 2,
                      Value = 50
                  },
                  new Donate {
                      Name = "Computer",
                      Note = "contact me in person",
                      CustomerId = 3,
                      DonateTypeId = 3,
                      Value = 2000
                  },
                  new Donate {
                      Name = "Tooth Brushs",
                      Note = "contact me in person",
                      CustomerId = 2,
                      DonateTypeId = 3,
                      Value = 610
                  },
                  new Donate {
                      Name = "Books",
                      Note = "contact me in person",
                      CustomerId = 4,
                      DonateTypeId = 3,
                      Value = 210
                  }
                };
                foreach (Donate i in Donates)
                {
                    context.Donate.Add(i);
                }
                context.SaveChanges();

                // 3  Customer.  - Seeding the database.
                var Customers = new Customer[]
                {
                  new Customer {
                      FullName = "Micheal Brown",
                      Street = "600 penselvenia ave",
                      State = "DC",
                      City = "washington",
                      Email = "Boby@gmail.com",
                      Telephone = 555-287-2516
                  },
                  new Customer {
                      FullName = "James Douglas",
                      Street = "300 infinity st",
                      State = "TN",
                      City = "Frankline",
                      Email = "James@gmail.com",
                      Telephone = 555-237-2416
                  },
                  new Customer {
                      FullName = "Sandra Miller",
                      Street = "27 Beverly hills ave",
                      State = "CA",
                      City = "Los Angles",
                      Email = "Sandray@gmail.com",
                      Telephone = 555-087-2396
                  },
                  new Customer {
                      FullName = "John Doe",
                      Street = "500 Interstate blvd",
                      State = "TN",
                      City = "Nasville",
                      Email = "John@gmail.com",
                      Telephone = 555-347-2522
                  }
                };
                foreach (Customer i in Customers)
                {
                    context.Customer.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}
   