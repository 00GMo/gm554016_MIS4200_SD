using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gm554016.Models
{
    public class Game
    {
        //"prop" + Tab + Tab shortcut
        public int gameID { get; set; }

        public string gameTitle { get; set; }

        public string gameSeries { get; set; }

        public string genreOne { get; set; }

        public string genreTwo { get; set; }

        public DateTime releaseDate { get; set; }

        public string description { get; set; }

        //Foreign Key for Console
        public int consolesID { get; set; }

        public virtual Consoles consoles { get; set; }

        //Foreign Key for Owner
        public int ownerID { get; set; }

        public virtual Owner owner { get; set; }

        //Foreign Key for Publisher
        public int publisherID { get; set; }

        public virtual Publisher publisher { get; set; }
    }
}