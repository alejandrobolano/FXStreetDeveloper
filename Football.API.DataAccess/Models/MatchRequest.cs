using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Football.API.Common.Models;

namespace Football.API.DataAccess.Models
{
    public class MatchRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public ManagerResponse HouseManager { get; set; }
        public ManagerResponse AwayManager { get; set; }

        public ICollection<PlayerResponse> HousePlayers { get; set; }
        public ICollection<PlayerResponse> AwayPlayers { get; set; }

        public RefereeResponse Referee { get; set; }
        public DateTime Date { get; set; }
    }
}
