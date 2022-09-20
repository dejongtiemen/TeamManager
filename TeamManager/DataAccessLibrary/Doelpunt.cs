using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Doelpunt
    {
        public string speler { get; set; }
        public int IDspeler { get; set; }
        public int minuut { get; set; }
        public int wedstrijdID { get; set; }
        public string team { get; set; }
        public override string ToString()
        {
            return $"{speler}   {minuut}'";
        }
    }
}
