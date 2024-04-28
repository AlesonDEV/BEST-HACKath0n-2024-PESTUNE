using BloodFlow.DataLayer.Data;
using BloodFlow.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodFlow.PresentaionLayer.Middleware
{
    public static class SeedDataMiddleware
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BloodFlowDbContext _context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetService<BloodFlowDbContext>();

            if (_context!.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();

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

            if (!_context.States.Any())
            {
                var states = new List<State>()
                {
                    new State() { Name = "Closed"},
                    new State() { Name = "Active"},
                };

                _context.AddRange(states);
            }

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
        }
    }
}
