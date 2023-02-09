namespace Football.API.Common.Models
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
