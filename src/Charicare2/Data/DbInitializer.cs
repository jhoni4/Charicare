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
                      Name = "Clothes"
                  },
                  new DonateType {
                      Name = "Financial/Money"
                  },
                  new DonateType {
                      Name = "Goods"
                  },
                  new DonateType {
                      Name = "Medical Supplies"
                  },
                };
                foreach (DonateType i in DonateTypes)
                {
                    context.DonateType.Add(i);
                }
                context.SaveChanges();

                // 2  ClothesDonate.  - Seeding the database.
                var ClothesDonates = new ClothesDonate[]
                {
                  new ClothesDonate {
                      Name = "Pillow",
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new ClothesDonate {
                      Name = "Blankets",
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new ClothesDonate {
                      Name = "Sheets",
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new ClothesDonate {
                      Name = "Soacks",
                      Note = "contact me in person",
                      UserId = 1
                  },
                  new ClothesDonate {
                      Name = "Pants",
                      Note = "contact me in person",
                      UserId = 1
                  }
                };
                foreach (ClothesDonate i in ClothesDonates)
                {
                    context.ClothesDonate.Add(i);
                }
                context.SaveChanges();

                // 3  MedicalDonates.  - Seeding the database.
                var MedicalDonates = new MedicalDonate[]
                {
                  new MedicalDonate {
                      Name = "Vitamine B12",
                      Note = "contact me in person",
                      UserId = 4
                  },
                  new MedicalDonate {
                      Name = "Advil",
                      Note = "contact me in person",
                      UserId = 2
                  },
                  new MedicalDonate {
                      Name = "Tylnole",
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new MedicalDonate {
                      Name = "Sanitaizer",
                      Note = "contact me in person",
                      UserId = 1
                  }
                };
                foreach (MedicalDonate i in MedicalDonates)
                {
                    context.MedicalDonate.Add(i);
                }
                context.SaveChanges();

                // 4  MoneyDonate.  - Seeding the database.
                var MoneyDonates = new MoneyDonate[]
                {
                  new MoneyDonate {
                      Amount = 300,
                      Note = "contact me in person",
                      UserId = 2
                  },
                  new MoneyDonate {
                      Amount = 200,
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new MoneyDonate {
                      Amount = 50,
                      Note = "contact me in person",
                      UserId = 1
                  },
                  new MoneyDonate {
                      Amount = 100,
                      Note = "contact me in person",
                      UserId = 2
                  }
                };
                foreach (MoneyDonate i in MoneyDonates)
                {
                    context.MoneyDonate.Add(i);
                }
                context.SaveChanges();

                // 5  GoodsDonate.  - Seeding the database.
                var GoodsDonates = new GoodsDonate[]
                {
                  new GoodsDonate {
                      Name = "mattress",
                      Note = "contact me in person",
                      UserId = 3
                  },
                  new GoodsDonate {
                      Name = "Tooth Brushs",
                      Note = "contact me in person",
                      UserId = 2
                  },
                  new GoodsDonate {
                      Name = "Books",
                      Note = "contact me in person",
                      UserId = 1
                  },
                  new GoodsDonate {
                      Name = "Plates",
                      Note = "contact me in person",
                      UserId = 1
                  }
                };
                foreach (GoodsDonate i in GoodsDonates)
                {
                    context.GoodsDonate.Add(i);
                }
                context.SaveChanges();

                // 5  User.  - Seeding the database.
                var Users = new User[]
                {
                  new User {
                      FullName = "Micheal Brown",
                      Street = "600 penselvenia ave",
                      State = "DC",
                      City = "washington",
                      Email = "Boby@gmail.com",
                      Telephone = 555-287-2516
                  },
                  new User {
                      FullName = "James Douglas",
                      Street = "300 infinity st",
                      State = "TN",
                      City = "Frankline",
                      Email = "James@gmail.com",
                      Telephone = 555-237-2416
                  },
                  new User {
                      FullName = "Sandra Miller",
                      Street = "27 Beverly hills ave",
                      State = "CA",
                      City = "Los Angles",
                      Email = "Sandray@gmail.com",
                      Telephone = 555-087-2396
                  },
                  new User {
                      FullName = "John Doe",
                      Street = "500 Interstate blvd",
                      State = "TN",
                      City = "Nasville",
                      Email = "John@gmail.com",
                      Telephone = 555-347-2522
                  }
                };
                foreach (User i in Users)
                {
                    context.User.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}
   