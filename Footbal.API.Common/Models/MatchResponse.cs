using System;
using System.Collections.Generic;

namespace Football.API.Common.Models
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ManagerResponse HouseManager { get; set; }
        public ManagerResponse AwayManager { get; set; }

        public ICollection<PlayerResponse> HousePlayers { get; set; }
        public ICollection<PlayerResponse> AwayPlayers { get; set; }

        public RefereeResponse Referee { get; set; }
        public DateTime Date { get; set; }
    }
}
