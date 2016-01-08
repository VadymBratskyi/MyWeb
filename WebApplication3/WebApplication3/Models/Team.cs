using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}