using System;
using System.Security.Cryptography.X509Certificates;
using Football.API.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Football.API.DataAccess
{
    public class FootballContext : DbContext
    {
        public DbSet<ManagerResponse> Managers { get; set; }
        public DbSet<PlayerResponse> Players { get; set; }
        public DbSet<RefereeResponse> Referees { get; set; }
        public DbSet<MatchResponse> Matches { get; set; }
        //public DbSet<CardResponse> Cards { get; set; }

        private static DbContextOptions<FootballContext> _options;
        public FootballContext(DbContextOptions<FootballContext> options)
            : base(options)
        {
            _options = options;
        }

        private static FootballContext _instance = null;
        private static readonly object Padlock = new object();

        public static FootballContext Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance != null) return _instance;
                    _instance = new FootballContext(_options);
                    return _instance;
                }
            }
        }


    }
}
