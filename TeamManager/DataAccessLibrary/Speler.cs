using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
   public enum Linie {Doel, Verdediging, Middenveld, Aanval }
    public class Speler
    {
        public string naam { get; set; }
        public int leeftijd { get; set; }
        public int lengte { get; set; }
        public int gewicht { get; set; }
        public string positie { get; set; }
        public int nummer { get; set; }
        public string team { get; set; }
        public Linie linie { get; set; }
        public int ID { get; set; }
        public List<Doelpunt> doelpunten { get; set; }
        public int aantalDoelpunten { get; set; }


        public Speler()
        {
            this.doelpunten = new List<Doelpunt>();
        }

        public void AddDoelpunt(Doelpunt doelpunt)
        {
            this.doelpunten.Add(doelpunt);
        }

        public void BerekenAantalDoelpunten()
        {
            aantalDoelpunten = doelpunten.Count;
        }

        public override string ToString()
        {
            return naam;
        }
    }
}
