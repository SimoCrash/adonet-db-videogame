using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public record Videogame
    {
        public Videogame(long id, string name, DateTime realease_date, long softwareHouse)
        {
            this.id = id;
            this.name = name;
            this.realease_date = realease_date;
            this.softwareHouse = softwareHouse;
        }

        public long id { get; set; }
        public string name { get; set; }
        public DateTime realease_date { get; set; }
        public long softwareHouse { get; set; }
    }
}
