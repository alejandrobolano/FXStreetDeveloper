using System.Linq;
using Football.API.Common.Models;

namespace Football.API.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(FootballContext context)
        {
            //var context = FootballContext.Instance;
            context.Database.EnsureCreated();

            if (context.Players.Any())
                return;

            InitializePlayers(context);

            InitializeManagers(context);

            InitializeReferees(context);
        }

        private static void InitializeReferees(FootballContext context)
        {
            var referees = new[]
            {
                new RefereeResponse { Name = "Pierluigi" },
                new RefereeResponse { Name = "Howard" }
            };

            foreach (var r in referees)
                context.Referees.Add(r);
            context.SaveChanges();
        }

        private static void InitializeManagers(FootballContext context)
        {
            var managers = new[]
            {
                new ManagerResponse { Name = "Alex" },
                new ManagerResponse { Name = "Zidane" },
                new ManagerResponse { Name = "Guardiola" }
            };

            foreach (var m in managers)
                context.Managers.Add(m);
            context.SaveChanges();
        }

        private static void InitializePlayers(FootballContext context)
        {
            var players = new[]
            {
                new PlayerResponse { Name = "Lionel" },
                new PlayerResponse { Name = "Cristiano" },
                new PlayerResponse { Name = "Iker" },
                new PlayerResponse { Name = "Gerard" },
                new PlayerResponse { Name = "Philippe" },
                new PlayerResponse { Name = "Jordi" }
            };

            foreach (var p in players)
                context.Players.Add(p);
            context.SaveChanges();
        }
    }
}
