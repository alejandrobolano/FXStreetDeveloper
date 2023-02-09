using System.ComponentModel.DataAnnotations;

namespace Football.API.Common.Models
{
    public class ManagerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
    }
}
