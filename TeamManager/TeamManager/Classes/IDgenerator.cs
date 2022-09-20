using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Classes
{
   static public class IDgenerator
    {
        static int coachID;
        static int spelerID;
        static int wedstrijduitslagID;
        

        static public int CoachIDToewijzen()
        {
            return coachID++;
        }

       static public int SpelerIDToewijzen()
        {
            return spelerID++;
        }

        static public int WedstrijduitslagIDToewijzen()
        {
            return wedstrijduitslagID++;
        }
    }
}
