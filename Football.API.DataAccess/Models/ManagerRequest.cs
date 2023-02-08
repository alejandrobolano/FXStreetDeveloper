using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.API.DataAccess.Models
{
    public class ManagerRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Team name is required")]
        public string TeamName { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
    }
}
