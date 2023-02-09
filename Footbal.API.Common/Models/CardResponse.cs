using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football.API.Common.Models
{
    public class CardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int Total { get; set; }
    }
}
