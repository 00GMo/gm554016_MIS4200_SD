using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gm554016.Models
{
    public class Publisher
    {
        public int publisherID { get; set; }

        public string publisherName { get; set; }

        public string hqLocation { get; set; }

        public string description { get; set; }

        public ICollection<Game> game { get; set; }
    }
}