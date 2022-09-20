using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
   public class TeamStatistieken
    {
        public int gespeeld { get; set; }
        public int gewonnen{ get; set; }
        public int gelijk{ get; set; }
        public int verloren{ get; set; }
        public int doelpuntenTegen { get; set; }
        public int doelpuntenVoor { get; set; }
        public int doelsaldo { get; set; }
        public int punten { get; set; }
        public string team { get; set; }
        public int positie { get; set; }


    }
}
