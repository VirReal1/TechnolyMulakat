using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnolyMulakat.Data.Abstracts;
using TechnolyMulakat.Entities.Concretes;

namespace TechnolyMulakat.Data.Concretes
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataLayerContext _context;
        private readonly ILogger _logger;

        public DatabaseInitializer(DataLayerContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            await SeedDemoDataAsync();
        }

        private async Task SeedDemoDataAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted))
            {
                try
                {
                    if (!await _context.Airports.AnyAsync() && !await _context.Cities.AnyAsync() && !await _context.Flights.AnyAsync())
                    {
                        _logger.LogInformation("Seeding demo data");

                        var cities = new CL_City[]
                            {
                                new CL_City { Id = 1, Name = "Adana" },
                                new CL_City { Id = 2, Name = "Adıyaman" },
                                new CL_City { Id = 3, Name = "Afyonkarahisar" },
                                new CL_City { Id = 4, Name = "Ağrı" },
                                new CL_City { Id = 5, Name = "Amasya" },
                                new CL_City { Id = 6, Name = "Ankara" },
                                new CL_City { Id = 7, Name = "Antalya" },
                                new CL_City { Id = 8, Name = "Artvin" },
                                new CL_City { Id = 9, Name = "Aydın" },
                                new CL_City { Id = 10, Name = "Balıkesir" },
                                new CL_City { Id = 11, Name = "Bilecik" },
                                new CL_City { Id = 12, Name = "Bingöl" },
                                new CL_City { Id = 13, Name = "Bitlis" },
                                new CL_City { Id = 14, Name = "Bolu" },
                                new CL_City { Id = 15, Name = "Burdur" },
                                new CL_City { Id = 16, Name = "Bursa" },
                                new CL_City { Id = 17, Name = "Çanakkale" },
                                new CL_City { Id = 18, Name = "Çankırı" },
                                new CL_City { Id = 19, Name = "Çorum" },
                                new CL_City { Id = 20, Name = "Denizli" },
                                new CL_City { Id = 21, Name = "Diyarbakır" },
                                new CL_City { Id = 22, Name = "Edirne" },
                                new CL_City { Id = 23, Name = "Elazığ" },
                                new CL_City { Id = 24, Name = "Erzincan" },
                                new CL_City { Id = 25, Name = "Erzurum" },
                                new CL_City { Id = 26, Name = "Eskişehir" },
                                new CL_City { Id = 27, Name = "Gaziantep" },
                                new CL_City { Id = 28, Name = "Giresun" },
                                new CL_City { Id = 29, Name = "Gümüşhane" },
                                new CL_City { Id = 30, Name = "Hakkari" },
                                new CL_City { Id = 31, Name = "Hatay" },
                                new CL_City { Id = 32, Name = "Isparta" },
                                new CL_City { Id = 33, Name = "Mersin" },
                                new CL_City { Id = 34, Name = "İstanbul" },
                                new CL_City { Id = 35, Name = "İzmir" },
                                new CL_City { Id = 36, Name = "Kars" },
                                new CL_City { Id = 37, Name = "Kastamonu" },
                                new CL_City { Id = 38, Name = "Kayseri" },
                                new CL_City { Id = 39, Name = "Kırklareli" },
                                new CL_City { Id = 40, Name = "Kırşehir" },
                                new CL_City { Id = 41, Name = "Kocaeli" },
                                new CL_City { Id = 42, Name = "Konya" },
                                new CL_City { Id = 43, Name = "Kütahya" },
                                new CL_City { Id = 44, Name = "Malatya" },
                                new CL_City { Id = 45, Name = "Manisa" },
                                new CL_City { Id = 46, Name = "Kahramanmaraş" },
                                new CL_City { Id = 47, Name = "Mardin" },
                                new CL_City { Id = 48, Name = "Muğla" },
                                new CL_City { Id = 49, Name = "Muş" },
                                new CL_City { Id = 50, Name = "Nevşehir" },
                                new CL_City { Id = 51, Name = "Niğde" },
                                new CL_City { Id = 52, Name = "Ordu" },
                                new CL_City { Id = 53, Name = "Rize" },
                                new CL_City { Id = 54, Name = "Sakarya" },
                                new CL_City { Id = 55, Name = "Samsun" },
                                new CL_City { Id = 56, Name = "Siirt" },
                                new CL_City { Id = 57, Name = "Sinop" },
                                new CL_City { Id = 58, Name = "Sivas" },
                                new CL_City { Id = 59, Name = "Tekirdağ" },
                                new CL_City { Id = 60, Name = "Tokat" },
                                new CL_City { Id = 61, Name = "Trabzon" },
                                new CL_City { Id = 62, Name = "Tunceli" },
                                new CL_City { Id = 63, Name = "Şanlıurfa" },
                                new CL_City { Id = 64, Name = "Uşak" },
                                new CL_City { Id = 65, Name = "Van" },
                                new CL_City { Id = 66, Name = "Yozgat" },
                                new CL_City { Id = 67, Name = "Zonguldak" },
                                new CL_City { Id = 68, Name = "Aksaray" },
                                new CL_City { Id = 69, Name = "Bayburt" },
                                new CL_City { Id = 70, Name = "Karaman" },
                                new CL_City { Id = 71, Name = "Kırıkkale" },
                                new CL_City { Id = 72, Name = "Batman" },
                                new CL_City { Id = 73, Name = "Şırnak" },
                                new CL_City { Id = 74, Name = "Bartın" },
                                new CL_City { Id = 75, Name = "Ardahan" },
                                new CL_City { Id = 76, Name = "Iğdır" },
                                new CL_City { Id = 77, Name = "Yalova" },
                                new CL_City { Id = 78, Name = "Karabük" },
                                new CL_City { Id = 79, Name = "Kilis" },
                                new CL_City { Id = 80, Name = "Osmaniye" },
                                new CL_City { Id = 81, Name = "Düzce" }
                            };

                        await _context.Cities.AddRangeAsync(cities);
                        await _context.SaveChangesAsync();

                        var airports = new CL_Airport[]
                            {
                                new CL_Airport { Id = 1, Name = "Adana Şakirpaşa Airport", CityId = 1 },
                                new CL_Airport { Id = 2, Name = "Adıyaman Airport", CityId = 2 },
                                new CL_Airport { Id = 3, Name = "Afyonkarahisar Airport", CityId = 3 },
                                new CL_Airport { Id = 4, Name = "Ağrı Ahmed-i Hani Airport", CityId = 4 },
                                new CL_Airport { Id = 5, Name = "Amasya Merzifon Airport", CityId = 5 },
                            };

                        await _context.Airports.AddRangeAsync(airports);
                        await _context.SaveChangesAsync();

                        string format = "dd-MM-yyyy";

                        var flights = new Flight[]
                            {
                                new Flight
                                {
                                    Id = 1,
                                    DepartureAirportId = 1,
                                    ArrivalAirportId = 2,
                                    DepartureDate = DateTime.ParseExact("22-06-2022", format, CultureInfo.InvariantCulture),
                                    ArrivalDate = DateTime.ParseExact("26-06-2022", format, CultureInfo.InvariantCulture),
                                    AircraftType = "Boeing 737",
                                    Apron = "A1",
                                    PilotName = "John Smith",
                                    CoPilotName = "Alice Johnson"
                                },
                                new Flight
                                {
                                    Id = 2,
                                    DepartureAirportId = 2,
                                    ArrivalAirportId = 3,
                                    DepartureDate = DateTime.ParseExact("30-07-2022", format, CultureInfo.InvariantCulture),
                                    ArrivalDate = DateTime.ParseExact("01-08-2022", format, CultureInfo.InvariantCulture),
                                    AircraftType = "Airbus A320",
                                    Apron = "B3",
                                    PilotName = "David Wilson",
                                    CoPilotName = "Emily Davis"
                                },
                            };

                        await _context.Flights.AddRangeAsync(flights);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        _logger.LogInformation("Seeding demo data completed");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    await transaction.RollbackAsync();
                }
            }
        }
    }

}