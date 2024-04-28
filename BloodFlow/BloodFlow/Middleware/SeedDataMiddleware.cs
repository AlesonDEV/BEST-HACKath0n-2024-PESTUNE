using BloodFlow.DataLayer.Data;
using BloodFlow.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodFlow.PresentaionLayer.Middleware
{
    public static class SeedDataMiddleware
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BloodFlowDbContext _context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetService<BloodFlowDbContext>();

            if (!_context.BloodTypes.Any())
            {
                var bloodTypes = new List<BloodType>()
                {
                    new BloodType() { Name = "O+" },
                    new BloodType() { Name = "O-" },
                    new BloodType() { Name = "A+" },
                    new BloodType() { Name = "A-" },
                    new BloodType() { Name = "B+" },
                    new BloodType() { Name = "B-" },
                    new BloodType() { Name = "AB+" },
                    new BloodType() { Name = "AB-" },
                };

                _context.AddRange(bloodTypes);
            }

            _context.SaveChanges();

            if (!_context.States.Any())
            {
                var states = new List<State>()
                {
                    new State() { Name = "Closed"},
                    new State() { Name = "Active"},
                };

                _context.AddRange(states);
            }

            _context.SaveChanges();

            if (!_context.Importances.Any())
            {
                var importances = new List<Importance>()
                {
                    new Importance() { Name = "Low" },
                    new Importance() { Name = "Medium" },
                    new Importance() { Name = "High" },
                };

                _context.AddRange(importances);
            }

            _context.SaveChanges();

            if (!_context.Cities.Any())
            {
                var cities = new List<City>()
                {
                    new City()
                    {
                        Name = "Kyiv",
                        Streets = new List<Street>()
                        {
                            new Street() {Name = "Khreshchatyk Street (main street)"},
                            new Street() {Name = "Independence Square"},
                            new Street() {Name = "Shevchenko Boulevard"},
                            new Street() {Name = "Andriyivski Uzviz (historical street)"},
                            new Street() {Name = "Hrushevskoho Street"},
                            new Street() {Name = "Sapehorne Pole (historical area)"},
                            new Street() {Name = "Lipova Street"},
                            new Street() {Name = "Saksahanskoho Street"},
                            new Street() {Name = "Shota Rustaveli Street"},
                            new Street() {Name = "Dniprovska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Kharkiv",
                        Streets  = new List<Street>()
                        {
                            new Street() {Name = "Sumska Street"},
                            new Street() {Name = "Freedom Square"},
                            new Street() {Name = "Shevchenko Avenue"},
                            new Street() {Name = "University Street"},
                            new Street() {Name = "Klochkivska Street"},
                            new Street() {Name = "Heroes of Kharkiv Street"},
                            new Street() {Name = "Mykolaivska Street"},
                            new Street() {Name = "Darvina Street"},
                            new Street() {Name = "Naukova Street (Science St.)"},
                        }
                    },
                    new City()
                    {
                        Name = "Odesa",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Deribasovska Street (popular tourist street)"},
                            new Street() { Name = "Primorska Street (beachfront street)"},
                            new Street() { Name = "Marshala Havrylova Street"},
                            new Street() { Name = "Frantsuzkyi Bulvar (French Boulevard)"},
                            new Street() { Name="Hretska Ploscha (Greek Square)"},
                            new Street() { Name = "Deribasivskyi Lane"},
                        }
                    },
                    new City()
                    {
                        Name = "Dnipro",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Shevchenko Prospekt (main avenue)"},
                            new Street() { Name = "Monastyrska Street (historical street)"},
                            new Street() { Name = "Karla Liebknechta Avenue"},
                            new Street() { Name = "Yevhen Konovalets Street"},
                            new Street() { Name = "Gagarin Avenue"},
                            new Street() { Name = "Slovyanskaya Street"},
                            new Street() { Name = "просpekt Dmytra Yakovleva (Dmytro Yakovleva Avenue)" },
                        }
                    },
                    new City()
                    {
                        Name = "Donetsk",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Artem Street (main street)"},
                            new Street() { Name = "Universytetska Street (University Street)"},
                            new Street() { Name = "Parkova Street (Park Street)"},
                            new Street() { Name = "Pushkina Street"},
                            new Street() { Name = "Shevchenko Boulevard"},
                            new Street() { Name = "Bahatyr Donetskiy Avenue"},
                            new Street() { Name = "Petropavlovka Street" },
                        }
                    },
                    new City()
                    {
                        Name = "Zaporizhzhia",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Sobornyi Avenue (main avenue)"},
                            new Street() { Name = "Peremaha Avenue (Victory Avenue)"},
                            new Street() { Name = "Dmytro Yakovlev Street"},
                            new Street() { Name = "Heorhiy Gongadze Avenue"},
                            new Street() { Name = "Metalurhiv Avenue"},
                            new Street() { Name = "Shoss Dovbzhenka (Dovzhenka Highway)"},
                            new Street() { Name = "Unity Street" },
                        }
                    },
                    new City()
                    {
                        Name = "Lviv",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Prospect Svobody (Freedom Avenue)"},
                            new Street() { Name = "Ploshcha Rynok (Market Square)"},
                            new Street() { Name = "vulytsya Shevchenka (Shevchenko Street)"},
                            new Street() { Name = "Halytska Street"},
                            new Street() { Name = "Lychakhivska Street"},
                            new Street() { Name = "Ruska Street (historic street)"},
                            new Street() { Name = "Sichovikh Strilkiv Avenue (Riflemen's Avenue)"},
                            new Street() { Name = "Kozyarska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Kryvyi Rih",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Metalurhiv Avenue (main avenue)"},
                            new Street() { Name = "Svoboda Avenue"},
                            new Street() { Name = "Shevchenko Boulevard"},
                            new Street() { Name = "Filatov Street"},
                            new Street() { Name = "Konyushyka Street"},
                            new Street() { Name = "Soborna Street (Cathedral Street)"},
                            new Street() { Name = "Yuriya Gagarina Boulevard"},
                            new Street() { Name = "Viktora Kulyka Street" },
                        }
                    },
                    new City()
                    {
                        Name = "Mykolaiv",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Soborna Street (Cathedral Street)"},
                            new Street() { Name = "Pushkinska Street"},
                            new Street() { Name = "Admyral Makarova Street"},
                            new Street() { Name = "Peremohy Street (Victory Street)"},
                            new Street() { Name = "Troїцька вулиця (Troitska Street)"},
                            new Street() { Name = "Mykolaivska Street"},
                            new Street() { Name = "Parovozna Street (Locomotive Street)"},
                            new Street() { Name = "Hurzufska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Vinnytsia",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Soborna Street (Cathedral Street)"},
                            new Street() { Name = "Kozyatskyi Street"},
                            new Street() { Name = "Kievskyi Shosse (Kiev Highway)"},
                            new Street() { Name = "Mykhaila Hrushevskogo Street"},
                            new Street() { Name = "Nechui-Levytsky Street"},
                            new Street() { Name = "Staryi Misto (Old Town area)" },
                            new Street() { Name = "Leontovycha Street"},
                            new Street() { Name = "Mykhaila Kotsiubynskoho Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Simferopol",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Pushkinskaya Street"},
                            new Street() { Name = "Kyivska Street"},
                            new Street() { Name = "Sebastopolskaya Street"},
                            new Street() { Name = "Prospekt Pobedy (Victory Avenue)"},
                            new Street() { Name = "Рози Люксембург"},
                            new Street() { Name = "Salgirskaya Street"},
                            new Street() { Name = " вулиця  Київська (Kyivska Street)" },
                            new Street() { Name = "Internacionalnaya Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Sevastopol",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Nakhimov Avenue"},
                            new Street() { Name = "Lenina Street"},
                            new Street() { Name = "Korabelnaya Naberezhnaya (Shipyard Embankment)"},
                            new Street() { Name = "Prospekt Generala Ostryaka (General Ostryak Avenue)"},
                            new Street() { Name = "Ushakova Balka (Ushakov Beam area)"},
                            new Street() { Name = "Batalayskaya Street"},
                            new Street() { Name = "Lev Tolstoy Street"},
                            new Street() { Name = "Pritytskiy Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Poltava",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Zhukova Street"},
                            new Street() { Name = "Shevchenko Park"},
                            new Street() { Name = "Sofiivska Street"},
                            new Street() { Name = "Oktyabrska Street)" },
                            new Street() { Name = "Shevchenko Street"},
                            new Street() { Name = "Kotlyarevskoho Street"},
                            new Street() { Name = "Zamolyvska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Chernihiv",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Hetmana Mazepy Street"},
                            new Street() { Name = "Dymytra Bortnyanskoho Street"},
                            new Street() { Name = "Ivana  Vyhovskoho"},
                            new Street() { Name = "Saints Cyril and Methodius Street"},
                            new Street() { Name = "Bratyrska Street"},
                            new Street() { Name = "Chernihivska Street"},
                            new Street() { Name = "Kyivska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Sumy",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Soborna Street"},
                            new Street() { Name = "Pervomayska Street"},
                            new Street() { Name = "Hetmana Vyrvy Street"},
                            new Street() { Name = "Antona Makarenka Street"},
                            new Street() { Name = "Smetanska Street" },
                            new Street() { Name = "Romska Street" },
                            new Street() { Name = "Prospekt Lypova Dolyna" },
                        }
                    },
                    new City()
                    {
                        Name = "Zhytomyr",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Kyivska Street"},
                            new Street() { Name = "Pushkinska Street"},
                            new Street() { Name = "Mykhaila Storozhenka Street"},
                            new Street() { Name = "Katedralna Street (Cathedral Street)"},
                            new Street() { Name = "Zabolotnoho Street"},
                            new Street() { Name = "Hipotezova Street"},
                            new Street() { Name = "Velyka Berdychivska Street (Great Berdychivska Street)"},
                            new Street() { Name = "Karoliinska Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Kirovohrad",
                        Streets  = new List<Street>()
                        {
                            new Street() { Name = "Evhena Chyho Avenue (main avenue)"},
                            new Street() { Name = "Heroes of Ukraine Square"},
                            new Street() { Name = "Kirov Street"},
                            new Street() { Name = "Shevchenko Boulevard"},
                            new Street() { Name = "Lehavaya Street"},
                            new Street() { Name = "Dniprovska Street"},
                            new Street() { Name = "Bohateriv Ukrainy Avenue (Heroes of Ukraine Avenue)"},
                            new Street() { Name = "Shevchenka Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Ivano-Frankivsk",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Hetmana Mazepy Street (main street)"},
                            new Street() { Name = "Shevchenko Street"},
                            new Street() { Name = "Nezalezhnosti Street (Independence Street)"},
                            new Street() { Name = "площа  Rynok (Market Square)"},
                            new Street() { Name = "Halycka Street"},
                            new Street() { Name = "Vasyliana Stefanyka Street"},
                            new Street() { Name = "Hrushevskoho Street"},
                            new Street() { Name = "Sichovikh Strilkiv Street (Riflemen's Street)"},
                        }
                    },
                    new City()
                    {
                        Name = "Ternopil",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Svobody Street (main street)"},
                            new Street() { Name = "Shevchenko Boulevard"},
                            new Street() { Name = "Berezhilka River Embankment"},
                            new Street() { Name = "Ruska Street"},
                            new Street() { Name = "Lipova Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Rivne",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Soborna Street (Cathedral Street)"},
                            new Street() { Name = "Post-Voyevodska Street"},
                            new Street() { Name = "Shevchenko Street"},
                            new Street() { Name = "Kyivska Street"},
                            new Street() { Name = "Legioniv Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Khmelnytskyi",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Proskurivska Street (main street)"},
                            new Street() { Name = "Svobody Square"},
                            new Street() { Name = "Trudova Street"},
                            new Street() { Name = "Chornovol Street"},
                            new Street() { Name = "Instytuta Street"},
                        }
                    },
                    new City()
                    {
                        Name = "Cherkasy",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Shevchenko Boulevard (main street)"},
                            new Street() { Name = "Khmelnytskyi Street"},
                            new Street() { Name = "Dniprovska Street"},
                            new Street() { Name = "Mykhaila Storozhenka Street"},
                            new Street() { Name = "Smilyanskaya Street"},
                            new Street() { Name =  "Lesya Ukrainka Boulevard"},
                            new Street() { Name =  "Yuri Gagarin Boulevard"},
                            new Street() { Name = "Saints Cyril and Methodius Street"},
                            new Street() { Name =  "Dniprovska Naberezhna (Dnipro Embankment)"},
                        }
                    },
                    new City()
                    {
                        Name = "Bila Tserkva",
                        Streets = new List<Street>()
                        {
                            new Street() { Name = "Kyivska Street"},
                            new Street() { Name = "Peremohy Street (Victory Street)"},
                            new Street() { Name = "Shevchenko Street"},
                            new Street() { Name = "Yaroslava Mudroho Street (Yaroslav the Wise Street)"},
                            new Street() { Name = "Odesa Street"},
                            new Street() { Name =  "Taras Bulba Street",},
                            new Street() { Name = "Soboarna Street (Cathedral Street)"},
                            new Street() { Name = "Stare Mystetske Highway (Old Town Highway)"},
                            new Street() { Name = "Parkova Street (Park Street)"},
                        }
                    }
                };

                _context.AddRange(cities);
            }

            _context.SaveChanges();

            if (!_context.DonorsCenter.Any())
            {
                var donorCenters = new List<DonorCenter>()
                {
                    new DonorCenter()
                    {
                        Name = "Saint Donor Center",
                        StreetId = 52,
                        HouseNumber = "23",
                        Contact = new Contact()
                        {
                            Name = "saintdonorcenter@gmail.com"
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                BloodTypeId = 3,
                                Title = "Need blood fro army!",
                                Description = "Our donor center need blood for army!",
                                BloodVolume = 10000,
                                ImportanceId = 1,
                            },
                            new Order()
                            {
                              BloodTypeId = 3,
                              Title = "Urgent blood needed for the military!",
                              Description = "Our donation center is in urgent need of blood for the military!",
                              BloodVolume = 10000,
                              ImportanceId = 1,
                            },
                            new Order()
                            {
                              BloodTypeId = 1,
                              Title = "Replenish universal blood type supplies",
                              Description = "Blood donors with universal blood type (1) are needed to maintain blood supplies!",
                              BloodVolume = 5000,
                              ImportanceId = 2,
                            },
                            new Order()
                            {
                              BloodTypeId = 2,
                              Title = "Blood donation drive! Be a hero!",
                              Description = "Join our blood donation drive and save lives! Details at...",
                              BloodVolume = 8000,
                              ImportanceId = 1,
                            },
                            new Order()
                            {
                              BloodTypeId = 4,
                              Title = "Blood needed for a child",
                              Description = "Blood type 4 is urgently needed for a child's treatment. Please respond!",
                              BloodVolume = 2000,
                              ImportanceId = 3,
                            },
                            new Order()
                            {
                              BloodTypeId = 2,
                              Title = "Regular blood donation saves lives",
                              Description = "Become a regular blood donor and help those in need!",
                              BloodVolume = 0,
                              ImportanceId = 2,
                            }
                        }
                    },
                    new DonorCenter()
                    {
                          Name = "Citywide Blood Services",
                          StreetId = 73,
                          HouseNumber = "14",
                          Contact = new Contact()
                          {
                               Name = "citywidebloodservices@clinic.org"
                          },
                          Orders = new List<Order>()
                          {
                                new Order()
                                {
                                  BloodTypeId = 1,
                                  Title = "Replenish universal blood type supplies",
                                  Description = "Blood donors with universal blood type (1) are needed to maintain blood supplies!",
                                  BloodVolume = 5000,
                                  ImportanceId = 2,
                                },
                                new Order()
                                {
                                  BloodTypeId = 4,
                                  Title = "Blood needed for a child",
                                  Description = "Blood type 4 is urgently needed for a child's treatment. Please respond!",
                                  BloodVolume = 2000,
                                  ImportanceId = 3,
                                },
                                new Order()
                                {
                                  BloodTypeId = 2,
                                  Title = "Regular blood donation saves lives",
                                  Description = "Become a regular blood donor and help those in need!",
                                  BloodVolume = 8000,
                                  ImportanceId = 2,
                                },
                          }
                    },
                    new DonorCenter()
                    {
                          Name = "Hope Haven Donation Center",
                          StreetId = 37,
                          HouseNumber = "12B",
                          Contact = new Contact()
                          {
                            Name = "hopehaven@donations.org"
                          },
                          Orders = new List<Order>()
                          {
                                new Order()
                                {
                                  BloodTypeId = 3,
                                  Title = "Urgent blood needed for the military!",
                                  Description = "Our donation center is in urgent need of blood for the military!",
                                  BloodVolume = 10000,
                                  ImportanceId = 1,
                                },
                                new Order()
                                {
                                  BloodTypeId = 1,
                                  Title = "Blood drive this weekend - all types needed!",
                                  Description = "Join our blood drive this weekend and help save lives! All blood types are welcome.",
                                  BloodVolume = 0,
                                  ImportanceId = 2,
                                },
                                new Order()
                                {
                                  BloodTypeId = 2,
                                  Title = "Blood donation appointment available!",
                                  Description = "Schedule your blood donation appointment today and make a difference!",
                                  BloodVolume = 0,
                                  ImportanceId = 2,
                                },
                          }
                    },
                };

                _context.AddRange(donorCenters);
            }

            _context.SaveChanges();

            //if (!_context.Donors.Any())
            //{
            //    var donors = new List<Donor>()
            //    {
            //        new Donor(){
            //            BloodTypeId = 1,
            //            Person = new Person()
            //            {
            //                Name = "Viktor",
            //                Surname = "Vashchuk",
            //                DateOfBirthday = new DateTime(2005, 10, 20),
            //                PhotoLink = "null",
            //                StreetId = 2,
            //                HouseNumber = "21",
            //                Contact = new Contact()
            //                {
            //                    Name = "viktor@gmail.com"
            //                }
            //            }
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 1,
            //            Person = new Person()
            //            {
            //                Name = "Іван",
            //                Surname = "Петренко",
            //                DateOfBirthday = new DateTime(2002, 03, 15),
            //                PhotoLink = "null",
            //                StreetId = 1,
            //                HouseNumber = "11",
            //                Contact = new Contact()
            //                {
            //                    Name = "ivan@ukr.net"
            //                }
            //            },
            //            //Sessions = new List<Session>()
            //            //{
            //            //    new Session()
            //            //    {
            //            //        DonorCenterId = 1,
            //            //        BloodVolume = 500,
            //            //        Date = new DateTime(2024, 02, 14),
            //            //        StateId = 1,
            //            //    },
            //            //    new Session() { DonorCenterId = 1, BloodVolume = 300, Date = new DateTime(2024, 03, 15), StateId = 2 },
            //            //    new Session() { DonorCenterId = 23, BloodVolume = 650, Date = new DateTime(2024, 04, 19), StateId = 2 },
            //            //    new Session() { DonorCenterId = 24, BloodVolume = 400, Date = new DateTime(2024, 02, 29), StateId = 1 },
            //            //}
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 2,
            //            Person = new Person()
            //            {
            //                Name = "Олена",
            //                Surname = "Сидоренко",
            //                DateOfBirthday = new DateTime(2004, 11, 27),
            //                PhotoLink = "null",
            //                StreetId = 3,
            //                HouseNumber = "12",
            //                Contact = new Contact()
            //                {
            //                    Name = "olena@gmail.com"
            //                }
            //            },
            //            //Sessions = new List<Session>()
            //            //{
            //            //    new Session()
            //            //    {
            //            //        DonorCenterId = 24,
            //            //        BloodVolume = 500,
            //            //        Date = new DateTime(2024, 02, 14),
            //            //        StateId = 1,
            //            //    },
            //            //    new Session() { DonorCenterId = 22, BloodVolume = 300, Date = new DateTime(2024, 03, 15), StateId = 2 },
            //            //    new Session() { DonorCenterId = 23, BloodVolume = 650, Date = new DateTime(2024, 04, 19), StateId = 2 },
            //            //    new Session() { DonorCenterId = 24, BloodVolume = 400, Date = new DateTime(2024, 02, 29), StateId = 1 },
            //            //}
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 3,
            //            Person = new Person()
            //            {
            //                Name = "Тарас",
            //                Surname = "Іващенко",
            //                DateOfBirthday = new DateTime(2001, 07, 09),
            //                PhotoLink = "null",
            //                StreetId = 2,
            //                HouseNumber = "19",
            //                Contact = new Contact()
            //                {
            //                    Name = "taras@i.ua"
            //                }
            //            }
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 4,
            //            Person = new Person()
            //            {
            //                Name = "Марія",
            //                Surname = "Попова",
            //                DateOfBirthday = new DateTime(2003, 05, 18),
            //                PhotoLink = "null",
            //                StreetId = 1,
            //                HouseNumber = "3",
            //                Contact = new Contact()
            //                {
            //                    Name = "maria@ukr.net"
            //                }
            //            },
            //            //Sessions = new List<Session>()
            //            //{
            //            //    new Session()
            //            //    {
            //            //        DonorCenterId = 24,
            //            //        BloodVolume = 500,
            //            //        Date = new DateTime(2024, 02, 14),
            //            //        StateId = 1,
            //            //    },
            //            //    new Session() { DonorCenterId = 22, BloodVolume = 200, Date = new DateTime(2024, 03, 22), StateId = 2 },
            //            //    new Session() { DonorCenterId = 23, BloodVolume = 800, Date = new DateTime(2024, 04, 26), StateId = 2 },
            //            //    new Session() { DonorCenterId = 24, BloodVolume = 600, Date = new DateTime(2024, 02, 10), StateId = 1 },
            //            //}
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 1,
            //            Person = new Person()
            //            {
            //                Name = "Андрій",
            //                Surname = "Новак",
            //                DateOfBirthday = new DateTime(2000, 12, 24),
            //                PhotoLink = "null",
            //                StreetId = 3,
            //                HouseNumber = "54",
            //                Contact = new Contact()
            //                {
            //                    Name = "andrii@gmail.com"
            //                }
            //            }
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 2,
            //            Person = new Person()
            //            {
            //                Name = "Анна",
            //                Surname = "Ковальчук",
            //                DateOfBirthday = new DateTime(2005, 04, 06),
            //                PhotoLink = "null",
            //                StreetId = 2,
            //                HouseNumber = "34",
            //                Contact = new Contact()
            //                {
            //                    Name = "anna@i.ua"
            //                }
            //            }
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 3,
            //            Person = new Person()
            //            {
            //                Name = "Сергій",
            //                Surname = "Петров",
            //                DateOfBirthday = new DateTime(2002, 08, 11),
            //                PhotoLink = "null",
            //                StreetId = 1,
            //                HouseNumber = "13",
            //                Contact = new Contact()
            //                {
            //                    Name = "serhii@ukr.net"
            //                }
            //            }
            //        },
            //        new Donor()
            //        {
            //            BloodTypeId = 4,
            //            Person = new Person()
            //            {
            //                Name = "Оксана",
            //                Surname = "Васильєва",
            //                DateOfBirthday = new DateTime(2004, 02, 03),
            //                PhotoLink = "null",
            //                HouseNumber = "23",
            //                StreetId = 3,
            //                Contact = new Contact()
            //                {
            //                    Name = "oksana@gmail.com"
            //                }
            //            },
            //            //Sessions = new List<Session>()
            //            //{
            //            //    new Session()
            //            //    {
            //            //        DonorCenterId = 22,
            //            //        BloodVolume = 500,
            //            //        Date = new DateTime(2024, 02, 14),
            //            //        StateId = 1,
            //            //    },
            //            //    new Session() { DonorCenterId = 22, BloodVolume = 500, Date = new DateTime(2024, 02, 14), StateId = 1 },
            //            //    new Session() { DonorCenterId = 23, BloodVolume = 250, Date = new DateTime(2024, 03, 08), StateId = 2 },
            //            //    new Session() { DonorCenterId = 24, BloodVolume = 700, Date = new DateTime(2024, 04, 22), StateId = 2 },
            //            //    new Session() { DonorCenterId = 22, BloodVolume = 550, Date = new DateTime(2024, 02, 01), StateId = 1 },
            //            //}
            //        },
            //    };

            //    _context.AddRange(donors);
            //}

            //if (!_context.DonorOrders.Any())
            //{
            //    var donorsOeders = new List<DonorOrder>
            //    {
            //        new DonorOrder()
            //        {
            //            OrderId = 4,
            //            DonorId = 1,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 7,
            //            DonorId = 3,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 10,
            //            DonorId = 2,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 1,
            //            DonorId = 6,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 8,
            //            DonorId = 4,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 1,
            //            DonorId = 9,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 5,
            //            DonorId = 2,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 4,
            //            DonorId = 5,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 3,
            //            DonorId = 1,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 6,
            //            DonorId = 3,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 4,
            //            DonorId = 4,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 7,
            //            DonorId = 3,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 8,
            //            DonorId = 3,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 6,
            //            DonorId = 2,
            //        },
            //        new DonorOrder()
            //        {
            //            OrderId = 2,
            //            DonorId = 5,
            //        },
            //    };

            //    _context.AddRange(donorsOeders);
            //}

            _context.SaveChanges();
        }
    }
}