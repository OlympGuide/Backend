using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre.Repositories
{
    public class TestDataRepository(OlympGuideDbContext context)
    {
        private static readonly string _guidBase = "274D2AE8-9853-4D26-B22E-FE296B77A";
        private static int _guidCounter = 0;

        private static readonly object Lock = new();

        private readonly Random random = new();

        public async Task<int> CreateTestData()
        {
            var users = await this.CreateTestUsers();
            var sportFields = await this.CreateTestSportFields();
            var reservations = await this.CreateTestReservations(sportFields, users);
            var sportFieldProposals = await this.CreateTestSportFieldProposals(users);

            Task.WaitAll(
                context.Users.AddRangeAsync(users),
                context.SportFields.AddRangeAsync(sportFields),
                context.Reservations.AddRangeAsync(reservations),
                context.SportFieldProposals.AddRangeAsync(sportFieldProposals));

            var amountCreated = await context.SaveChangesAsync();
            return amountCreated;
        }

        public async Task<int> DeleteTestData()
        {
            var sportFieldProposalsToRemove = context.SportFieldProposals
                .Where(sfp => sfp.Id.ToString().StartsWith(_guidBase, StringComparison.InvariantCultureIgnoreCase));

            var sportFieldsToRemove = context.SportFields
                .Where(sf => sf.Id.ToString().StartsWith(_guidBase, StringComparison.InvariantCultureIgnoreCase));

            var reservationsToRemove = context.Reservations
                .Where(r => r.Id.ToString().StartsWith(_guidBase, StringComparison.InvariantCultureIgnoreCase));

            var usersToRemove = context.Users
                .Where(u => u.Id.ToString().StartsWith(_guidBase, StringComparison.InvariantCultureIgnoreCase));

            context.SportFieldProposals.RemoveRange(sportFieldProposalsToRemove);
            context.SportFields.RemoveRange(sportFieldsToRemove);
            context.Reservations.RemoveRange(reservationsToRemove);
            context.Users.RemoveRange(usersToRemove);

            var amountDeleted = await context.SaveChangesAsync();
            return amountDeleted;
        }

        #region Test Data Creation

        private async Task<List<UserProfile>> CreateTestUsers()
        {
            return await Task.Run(() =>
            {
                var userProfiles = new List<UserProfile>()
                {
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Sven Schäfer",
                        DisplayName = "schöfli",
                        Email = "SvenSchaefer@zhaw.ch",
                        Roles = new() { UserRole.DefaultUser }
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Katrin Kaestner",
                        DisplayName = "katy",
                        Email = "KatrinKaestner@zhaw.ch",
                        Roles = new() { UserRole.DefaultUser }
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Amélie Pelland",
                        DisplayName = "pellerine",
                        Email = "AméliePelland@zhaw.ch",
                        Roles = new() { UserRole.DefaultUser }
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Alfonso Ferrari",
                        DisplayName = "ferrari",
                        Email = "AlfonsoFerrari@zhaw.ch",
                        Roles = new() { UserRole.DefaultUser }
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Fabrice Cyr",
                        DisplayName = "fafa",
                        Email = "FabriceCyr@zhaw.ch",
                        Roles = new() { UserRole.DefaultUser }
                    }
                };

                return userProfiles;
            });
        }

        private async Task<List<SportFieldType>> CreateTestSportFields()
        {
            return await Task.Run(() =>
            {
                var sportFields = new List<SportFieldType>
                {
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "ASVZ Sport Center Winterthur",
                        Description =
                            "Der ASVZ bietet allen Hochschulangehörigen ein attraktives und vielfältiges Sportangebot, in welchem es immer wieder Neues zu entdecken gibt und Bewährtes erhalten bleibt. Im ASVZ stehen die Menschen, die Freude an der Bewegung, die Fitness, der Ausgleich zum Studium bzw. Beruf und die Verbesserung der Lebensqualität im Zentrum.",
                        Latitude = 47.49371318423971,
                        Longitude = 8.717093499632721,
                        Address = "Lagerplatz 28, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "TCE Tennis Club",
                        Description =
                            "Wir sind ein multikultureller Tennis Club mit einer guten Durchmischung von Hobby- und Turnierspielern / -spielerinnen. Junge, auch schon etwas Betagtere und Junioren sind bei uns sehr willkommen und fühlen sich sehr bald wohl im Club. Anfänger und auch Fortgeschrittene geniessen den Sport und auch das Gesellige des Clublebens. Gerne sind auch alteingesessene Spieler bereit, mit Neumitgliedern zu spielen.",
                        Latitude = 47.501729507221825,
                        Longitude = 8.713984116905758,
                        Address = "Schützenwiesenweg 6, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Fussballplatz Schulhaus Heiligberg",
                        Latitude = 47.49544674677959,
                        Longitude = 8.726180906746624,
                        Address = "Hochwachtstrasse 9, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Fussballplatz Primarschule Schönengrund",
                        Latitude = 47.49357557304693,
                        Longitude = 8.737344514983741,
                        Address = "Weberstrasse 2, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Seilpark Winterthur",
                        Latitude = 47.49260861980515,
                        Longitude = 8.73556178955866,
                        Address = "Zeughausstrasse 54, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Basketballplatz",
                        Latitude = 47.502103671462486,
                        Longitude = 8.731687249268996,
                        Address = "Trollstrasse, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Fussballplatz",
                        Latitude = 47.50176868409301,
                        Longitude = 8.731603411044478,
                        Address = "Trollstrasse, 8400 Winterthur"
                    },
                    new()
                    {
                        Id = GenerateGuid(),
                        Name = "Volleyballplatz Rennweg",
                        Latitude = 47.502792309674476,
                        Longitude = 8.714411669067376,
                        Address = "Wartstrasse 71, 8400 Winterthur"
                    },
                };

                return sportFields;
            });
        }

        private async Task<List<ReservationType>> CreateTestReservations(List<SportFieldType> sportFields, List<UserProfile> users)
        {
            return await Task.Run(() =>
            {
                var reservations = new List<ReservationType>();

                const int reservationsPerSportField = 20;

                const int reservationPeriodHourStart = 7;
                const int reservationPeriod = 14;

                foreach (var sportField in sportFields)
                {
                    var currentHour = 0;
                    var currentDay = -1;

                    for (var i = 0; i < reservationsPerSportField; i++)
                    {
                        var startHour = currentHour += random.Next(0, 6);
                        var endHour = currentHour += random.Next(1, 3);

                        reservations.Add(new ReservationType
                        {
                            Id = GenerateGuid(),
                            SportFieldId = sportField.Id,
                            User = users[random.Next(0, users.Count)],
                            Start = this.GenerateDateTimeForReservation(currentDay,
                                reservationPeriodHourStart + startHour),
                            End = this.GenerateDateTimeForReservation(currentDay, reservationPeriodHourStart + endHour),
                            State = ReservationStates.Approved,
                        });

                        if (currentHour > reservationPeriod)
                        {
                            currentDay++;
                            currentHour = 0;
                        }
                    }
                }

                return reservations;
            });
        }

        private async Task<List<SportFieldProposalType>> CreateTestSportFieldProposals(List<UserProfile> users)
        {
            return await Task.Run(() =>
            {
                var sportFieldProposals = new List<SportFieldProposalType>
                {
                    new()
                    {
                        Id = GenerateGuid(),
                        Date = DateTime.Now,
                        User = users[random.Next(0, users.Count)],
                        SportFieldName = "Salzhaus",
                        SportFieldDescription =
                            "Nacht- und Musikclub in ehemaligem Lagerhaus mit regelmässigen Livekonzerten und Gast-DJs.",
                        SportFieldLatitude = 47.49754039335906,
                        SportFieldLongitude = 8.722296236745477,
                        SportFieldAddress = "untere Vogelsangstrasse 6, 8400 Winterthur"
                    }
                };

                return sportFieldProposals;
            });
        }

        #endregion

        #region Misc

        private static Guid GenerateGuid()
        {
            lock (Lock)
            {
                var index = _guidCounter.ToString("X3");
                
                var newGuidString = string.Concat(_guidBase, index);
                var newGuid = Guid.Parse(newGuidString);

                _guidCounter++;

                return newGuid;
            }
        }

        private DateTime GenerateDateTimeForReservation(int day, int hour)
        {
            var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
                .AddDays(day)
                .AddHours(hour);

            return dateTime;
        }

        #endregion
    }
}
