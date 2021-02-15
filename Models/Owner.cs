using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gm554016.Models
{
    public class Owner
    {
        public int ownerID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string fullName
        {
            get
            { return lastName + ", " + firstName; }
        }

        public string email { get; set; }

        public string phone { get; set; }

        public ICollection<Game> game { get; set; }
    }
}