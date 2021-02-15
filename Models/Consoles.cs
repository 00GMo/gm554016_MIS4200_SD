using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gm554016.Models
{
    public class Consoles
    {
        public int consolesID { get; set; }

        public string consoleName { get; set; }

        public DateTime releaseDate { get; set; }

        public string description { get; set; }

        public int developerID { get; set; }

        public virtual Developer developer { get; set; }

        public ICollection<Game> game { get; set; }
    }
}