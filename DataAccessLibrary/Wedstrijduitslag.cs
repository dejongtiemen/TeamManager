using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Wedstrijduitslag : INotifyPropertyChanged
    {
        public string thuisTeam { get; set; }
        public string uitTeam { get; set; }
        public int scoreUit { get; set; }
        public int scoreThuis { get; set; }
        public string datum { get; set; }
        public int wedstrijdUitslagID { get; set; }
        public List<Doelpunt> thuisDoelpuntenList { get; set; }
        public List<Doelpunt> uitDoelpuntenList { get; set; }
        public string thuisdoelpuntenString;
        public string uitdoelpuntenString;


        public Wedstrijduitslag()
        {
            thuisDoelpuntenList = new List<Doelpunt>();
            uitDoelpuntenList = new List<Doelpunt>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        public void thuisdoelpuntenListToSTring()
        {
            thuisDoelpuntenList.Sort((x, y) => x.minuut.CompareTo(y.minuut));
            for(int i = 0; i < thuisDoelpuntenList.Count; i++)
            {
                thuisdoelpuntenString += $"{thuisDoelpuntenList.ElementAt(i).speler}  {thuisDoelpuntenList.ElementAt(i).minuut}'";
                thuisDoelpuntenList.Remove(thuisDoelpuntenList.ElementAt(i));
                for(int j = 0; j < thuisDoelpuntenList.Count; j++)
                {
                    if(thuisDoelpuntenList.ElementAt(i).speler == thuisDoelpuntenList.ElementAt(j).speler)
                    {
                        thuisdoelpuntenString += $", {thuisDoelpuntenList.ElementAt(j).minuut}'";
                        thuisDoelpuntenList.Remove(thuisDoelpuntenList.ElementAt(j));
                    }
                }
                thuisdoelpuntenString += "\n";
            }
            
        }

        public void uitdoelpuntenListToSTring()
        {
           uitDoelpuntenList.Sort((x, y) => x.minuut.CompareTo(y.minuut));
            for (int i = 0; i < uitDoelpuntenList.Count; i++)
            {
                uitdoelpuntenString += $"{uitDoelpuntenList.ElementAt(i).speler}  {uitDoelpuntenList.ElementAt(i).minuut}'";
                uitDoelpuntenList.Remove(uitDoelpuntenList.ElementAt(i));
                for (int j = 0; j < uitDoelpuntenList.Count; j++)
                {
                    if (uitDoelpuntenList.ElementAt(i).speler == uitDoelpuntenList.ElementAt(j).speler)
                    {
                        uitdoelpuntenString += $", {uitDoelpuntenList.ElementAt(j).minuut}'";
                        uitDoelpuntenList.Remove(uitDoelpuntenList.ElementAt(j));
                    }
                }
                uitdoelpuntenString += "\n";
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string ThuisdoelpuntenString
        {
            get
            {
                return this.thuisdoelpuntenString;
            }

            set
            {
                this.thuisdoelpuntenString = value;
                OnPropertyChanged();
            }
        }

        public string UitdoelpuntenString
        {
            get
            {
                return this.uitdoelpuntenString;
            }

            set
            {
                this.uitdoelpuntenString = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return wedstrijdUitslagID.ToString();
        }
    }
}
