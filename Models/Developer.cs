using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gm554016.Models
{
    public class Developer
    {
        public int developerID { get; set; }

        public string developerName { get; set; }

        public string hqLocation { get; set; }

        public string description { get; set; }

        public ICollection<Consoles> consoles { get; set; }
    }
}