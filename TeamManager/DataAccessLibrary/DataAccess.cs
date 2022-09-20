using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;


namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public async static void InitiateDatabase()
        {
            //database file aanmaken en de nodige Tables Creeëren
            await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("teamManager.db", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string dbpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

               String tableCommand = "CREATE TABLE IF NOT " +
                 "EXISTS Competitie (Naam NVARCHAR(50) PRIMARY KEY); ";

                SqliteCommand createTableCompetitie = new SqliteCommand(tableCommand, db);

                createTableCompetitie.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Team (Naam NVARCHAR(50) PRIMARY KEY, " +
                    "Land NVARCHAR(50) ," +
                    "Competitie NVARCHAR(50)," +
                    "FOREIGN KEY (Competitie) REFERENCES Competitie(Naam) ON DELETE CASCADE); ";

                SqliteCommand createTableTeam = new SqliteCommand(tableCommand, db);

                createTableTeam.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS speler (Naam NVARCHAR(50), " +
                    "Leeftijd INTEGER," +
                    "Lengte INTEGER," +
                    "Gewicht INTEGER," +
                    "Positie NVARCHAR(50)," +
                    "Nummer INTEGER," +
                    "ID INTEGER PRIMARY KEY," +
                    "Team NVARCHAR(50)," +
                    "FOREIGN KEY (Team) REFERENCES Team(Naam) ON DELETE CASCADE) ";
                
                SqliteCommand createTableSpeler = new SqliteCommand(tableCommand, db);

                createTableSpeler.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                   "EXISTS Coach (Naam NVARCHAR(50)," +
                   "Leeftijd INTEGER," +
                   "ID INTEGER PRIMARY KEY," +
                   "Team NVARCHAR(50)," +
                   "FOREIGN KEY (Team) REFERENCES Team(Naam) ON DELETE CASCADE); ";

                SqliteCommand createTableCoach = new SqliteCommand(tableCommand, db);

                createTableCoach.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                  "EXISTS Teamstatistieken (Gespeeld INTEGER," +
                  "Gewonnen INTEGER," +
                  "Gelijk INTEGER," +
                  "Verloren INTEGER," +
                  "DoelpuntenVoor INTEGER," +
                  "DoelpuntenTegen INTEGER," +
                  "Doelsaldo INTEGER," +
                  "Punten INTEGER," +
                  "Team NVARCHAR(50), " +
                  "FOREIGN KEY (Team) REFERENCES Team(Naam) ON DELETE CASCADE)";

                SqliteCommand createTableTeamstatistieken = new SqliteCommand(tableCommand, db);

                createTableTeamstatistieken.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                 "EXISTS WedstrijdUitslag (ThuisTeam NVARCHAR(50)," +
                 "UitTeam NVARCHAR(50)," +
                 "ScoreUit INTEGER," +
                 "ScoreThuis INTEGER," +
                 "ID INTEGER PRIMARY KEY," +
                 "Datum NVARCHAR(50)," +
                 "FOREIGN KEY (ThuisTeam) REFERENCES Team(Naam) ON DELETE CASCADE," +
                 "FOREIGN KEY (UitTeam) REFERENCES Team(Naam) ON DELETE CASCADE); ";

                SqliteCommand createTableWedstrijdUitslagen = new SqliteCommand(tableCommand, db);

                createTableWedstrijdUitslagen.ExecuteReader();

                tableCommand = "CREATE TABLE IF NOT " +
                "EXISTS Doelpunt(SpelerID INTEGER ," +
                "SpelerNaam NVARCHAR(30)," +
                "Minuut INTEGER," +
                "WedstrijdID INTEGER," +
                "Team NVARCHAR(50)," +
                "FOREIGN KEY (WedstrijdID) REFERENCES WedstrijdUitslag(ID) ON DELETE CASCADE," +
                "FOREIGN KEY (SpelerID) REFERENCES Speler(ID) ON DELETE CASCADE," +
                "FOREIGN KEY (Team) REFERENCES Team(Naam) ON DELETE CASCADE);";

                SqliteCommand createTableDoelpunt = new SqliteCommand(tableCommand, db);

                createTableDoelpunt.ExecuteReader();

                db.Close();
            }
        }

        public static void AddCompetitie(String competitie)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommandCompetitie = new SqliteCommand();
                insertCommandCompetitie.Connection = db;

                insertCommandCompetitie.CommandText = $"INSERT INTO Competitie (Naam) VALUES ('{competitie}')";

                insertCommandCompetitie.ExecuteReader();

                db.Close();
            }
        }

        public static void DeleteCompetitie(string competitie)
        {
            //delete team uit de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Competitie WHERE Naam = '{competitie}';";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static void AddTeam(string naam, string land, string competitie)
        {
            //verbinden met database en team, competitie en teamstatistieken indien nodig toevoegen aan de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
               
                SqliteCommand insertCommandTeam = new SqliteCommand();
                insertCommandTeam.Connection = db;

                insertCommandTeam.CommandText = $"INSERT INTO Team (Naam, Land, Competitie) VALUES ('{naam}', '{land}', '{competitie}');";                

                insertCommandTeam.ExecuteReader();


                SqliteCommand insertCommandTeamstatistieken = new SqliteCommand();
                insertCommandTeamstatistieken.Connection = db;

                insertCommandTeamstatistieken.CommandText = $"INSERT INTO Teamstatistieken (Gespeeld, Gewonnen, Gelijk, Verloren, DoelpuntenVoor, DoelpuntenTegen, Doelsaldo, Punten, Team) VALUES ('0', '0', '0', '0', '0', '0', '0', '0', '{naam}');";

                insertCommandTeamstatistieken.ExecuteReader();

                db.Close();
            }
        }

        public static void DeleteTeam(string naam)
        {
            //delete team uit de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"UPDATE Team SET Competitie = NULL WHERE Naam = '{naam}' ;";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<String> GetTeams()
        {
            //teams opvragen van de database
            List<String> teams = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Naam, Land, Competitie from Team", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    teams.Add(query.GetString(0));
                }

                db.Close();
            }

            return teams;
        }

        public static List<String> GetTeams(string competitie)
        {
            //teams opvragen van de database
            List<String> teams = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam from Team WHERE Competitie = '{competitie}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    teams.Add(query.GetString(0));
                }

                db.Close();
            }
            return teams;
        }

            public static List<Speler> GetSpelers(string team)
        {
            //spelers opvragen van de database
            List<Speler> spelers = new List<Speler>();
            
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam, Leeftijd, Lengte, Gewicht, Positie, Nummer, ID FROM speler WHERE Team='{team}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Linie l;
                   if(query.GetString(4) == "GK")
                    {
                        l = Linie.Doel;
                    } 
                    else if (query.GetString(4) == "LB" | query.GetString(4) == "CV" | query.GetString(4) == "RB")
                    {
                        l = Linie.Verdediging;
                    }
                    else if (query.GetString(4) == "RM" | query.GetString(4) == "CM" | query.GetString(4) == "CAM" | query.GetString(4) == "CVM" | query.GetString(4) == "LM")
                    {
                        l = Linie.Middenveld;
                    }
                    else
                    {
                        l = Linie.Aanval;
                    }
                    spelers.Add(new Speler {naam = query.GetString(0), leeftijd = Int32.Parse(query.GetString(1)), lengte = Int32.Parse(query.GetString(2)), gewicht = Int32.Parse(query.GetString(3)), positie = query.GetString(4), nummer = Int32.Parse(query.GetString(5)), linie = l, ID = Int32.Parse(query.GetString(6)) });
                }

                db.Close();
            }

            return spelers;
        }

        public static List<Speler> GetDoelpuntenmakersCompetitie(string competitie)
        {
            List<string> teams = GetTeams(competitie);
            List<Speler> spelers = new List<Speler>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                foreach (string team in teams)
                {
                    SqliteCommand selectCommand = new SqliteCommand
                        ($"SELECT SpelerNaam, SpelerID FROM Doelpunt WHERE Team='{team}'", db);

                    SqliteDataReader query = selectCommand.ExecuteReader();

                    while (query.Read())
                    {
                        spelers.Add(new Speler { naam = query.GetString(0), ID = Int32.Parse(query.GetString(1)) });
                    }
                }
            }
            return spelers;
        }

        public static Speler getSpeler(int ID)
        {
            Speler speler =  new Speler();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam, Leeftijd, Lengte, Gewicht, Positie, Nummer, ID FROM speler WHERE ID ='{ID}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    speler = new Speler { naam = query.GetString(0), leeftijd = Int32.Parse(query.GetString(1)), lengte = Int32.Parse(query.GetString(2)), gewicht = Int32.Parse(query.GetString(3)), positie = query.GetString(4), nummer = Int32.Parse(query.GetString(5)), ID = Int32.Parse(query.GetString(6)) };
                }

                db.Close();
            }

            return speler;
        }

        public static bool IsNummerAlInGebruik(int nummer, string team)
        {
            bool isInGebruik;
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam, Leeftijd, Lengte, Gewicht, Positie, Nummer, ID FROM speler WHERE Nummer ='{nummer}' AND Team = '{team}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                isInGebruik = query.Read();
                
                db.Close();
            }

            return isInGebruik;
        }

        public static List<string> getCompeties()
        {
            List<string> competities = new List<string>();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam FROM Competitie", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    competities.Add(query.GetString(0));
                }

                db.Close();
            }

            return competities;
        }

        public static List<string> getLanden()
        {
            List<string> landen = new List<string>();           

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Land FROM Team", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Boolean isLandDubbel = false;
                    foreach (string land in landen)
                    {
                        if (land.Equals(query.GetString(0)))
                        {
                            isLandDubbel = true;
                        }
                    }
                    if (isLandDubbel == false)
                    {
                        landen.Add(query.GetString(0));
                    }
                }

                db.Close();
            }

            return landen;
        }

        public static void AddSpeler(string naam, string leeftijd, string lengte, int gewicht, string positie, int nummer, int ID, string team)
        {
            //team en competitie indien nodig toevoegen aan de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"INSERT INTO speler (Naam, Leeftijd, Lengte, Gewicht, Positie, Nummer, Team) VALUES ('{naam}', '{leeftijd}', '{lengte}', '{gewicht}', '{positie}', '{nummer}', '{team}');";

                insertCommand.ExecuteReader();


                db.Close();
            }
        }

        public static void SpelerBewerken(string naam, string leeftijd, string lengte, int gewicht, string positie, int nummer, string team, int ID)
        {
            //team en competitie indien nodig toevoegen aan de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"UPDATE Speler SET Naam = '{naam}', Leeftijd = '{leeftijd}', Lengte = '{lengte}', Gewicht = '{gewicht.ToString()}', Positie = '{positie}', Nummer = '{nummer.ToString()}', Team = '{team}' WHERE ID = '{ID.ToString()}';";

                insertCommand.ExecuteReader();


                db.Close();
            }
        }

        public static void DeleteSpeler(string ID)
        {
            //delete speler uit de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"UPDATE speler SET Team = NULL WHERE ID = '{ID}' ;";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static void Addcoach(string naam, string leeftijd, string team)
        {
            //coach toevoegen aan de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"INSERT INTO Coach (Naam, Leeftijd, Team) Values ('{naam}', '{leeftijd}', '{team}');";

                insertCommand.ExecuteReader();


                db.Close();
            }
        }

        public static void DeleteCoach(string naam)
        {
            //delete speler uit de database
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Coach WHERE Naam = '{naam}' ;";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static String GetCoach(string team)
        {
            //coach opvragen van de database
            string coach ="";

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Naam FROM coach WHERE Team = '{team}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    coach = query.GetString(0);
                }
                db.Close();
            }

            return coach;
        }

        public static void AddWedstrijdUitslag(string thuisteam, string uitteam, int thuisScore, int uitScore, int ID, string datum)
        {
            int uitslagIndex = thuisScore - uitScore;

            //verbinden met database  
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                //wedstrijduitslag toevoegen aan de database
                SqliteCommand insertCommandWedstrijduitslag = new SqliteCommand();
                insertCommandWedstrijduitslag.Connection = db;

                insertCommandWedstrijduitslag.CommandText = $"INSERT INTO WedstrijdUitslag (ThuisTeam, UitTeam, ScoreUit, ScoreThuis, ID, Datum) VALUES ('{thuisteam}', '{uitteam}', '{uitScore}', '{thuisScore}', '{ID}', '{datum}');";

                insertCommandWedstrijduitslag.ExecuteReader();

                //statistieken per team ophalen zodat ze kunnen worden bijgewerkt
                List<string> statistiekenThuisteam = GetTeamstatistieken(thuisteam);
                List<string> statistiekenUitteam = GetTeamstatistieken(uitteam);

                //strings uit de lijst updaten
                int thuisTeamGespeeld = Int32.Parse(statistiekenThuisteam[0]) + 1;
                int thuisTeamDoelpuntenVoor = Int32.Parse(statistiekenThuisteam[4]) + thuisScore;
                int thuisTeamDoelpuntenTegen = Int32.Parse(statistiekenThuisteam[5]) + uitScore;
                int thuisTeamDoelsaldo = Int32.Parse(statistiekenThuisteam[6]) + (thuisScore - uitScore);

                int uitTeamGespeeld = Int32.Parse(statistiekenUitteam[0]) + 1;
                int uitTeamDoelpuntenVoor = Int32.Parse(statistiekenUitteam[4]) + uitScore;
                int uitTeamDoelpuntenTegen = Int32.Parse(statistiekenUitteam[5]) + thuisScore;
                int uitTeamDoelsaldo = Int32.Parse(statistiekenUitteam[6]) + (uitScore - thuisScore);

                //deze waarden updaten
                SqliteCommand insertCommandStatistiekenThuisTeam1 = new SqliteCommand();
                insertCommandStatistiekenThuisTeam1.Connection = db;

                insertCommandStatistiekenThuisTeam1.CommandText = $"UPDATE Teamstatistieken SET Gespeeld = '{thuisTeamGespeeld}', DoelpuntenVoor = '{thuisTeamDoelpuntenVoor}', DoelpuntenTegen = '{thuisTeamDoelpuntenTegen}', Doelsaldo = '{thuisTeamDoelsaldo}' WHERE Team = '{thuisteam}';";

                insertCommandStatistiekenThuisTeam1.ExecuteReader();


                SqliteCommand insertCommandStatistiekenUitTeam1 = new SqliteCommand();
                insertCommandStatistiekenUitTeam1.Connection = db;

                insertCommandStatistiekenUitTeam1.CommandText = $"UPDATE Teamstatistieken SET Gespeeld = '{uitTeamGespeeld}', DoelpuntenVoor = '{uitTeamDoelpuntenVoor}', DoelpuntenTegen = '{uitTeamDoelpuntenTegen}', Doelsaldo = '{uitTeamDoelsaldo}' WHERE Team = '{uitteam}';";

                insertCommandStatistiekenUitTeam1.ExecuteReader();


                // winst, gelijk of verlies bepalen en invoeren in de table teamstatistieken (> 0 = winst thuisteam, 0 = gelijk, <0 = verlies)
                if (uitslagIndex > 0)
                {
                   
                    int gewonnen = Int32.Parse(statistiekenThuisteam[1]) + 1;                   
                    int verloren = Int32.Parse(statistiekenUitteam[3]) + 1;
                    int punten = Int32.Parse(statistiekenThuisteam[7]) +3;

                    //thuisteam bijwerken
                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Gewonnen = '{gewonnen}', Punten = '{punten}' WHERE Team = '{thuisteam}';";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();

                    //uitteam bijwerken
                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Verloren = '{verloren}' WHERE Team = '{uitteam}';";

                    insertCommandStatistiekenUitTeam2.ExecuteReader();

                } else if (uitslagIndex == 0)
                {

                    int gelijk = Int32.Parse(statistiekenThuisteam[2]) + 1;
                    int gelijk2 = Int32.Parse(statistiekenUitteam[2]) + 1;
                    int puntenThuis = Int32.Parse(statistiekenThuisteam[7]) + 1;
                    int puntenUit = Int32.Parse(statistiekenUitteam[7]) + 1;

                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Gelijk = '{gelijk}', Punten = '{puntenThuis}' WHERE Team = '{thuisteam}' ;";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();


                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Gelijk = '{gelijk2}', Punten = '{puntenUit}' WHERE Team = '{uitteam}' ;";
                   
                    insertCommandStatistiekenUitTeam2.ExecuteReader();
                }
                else
                {
                    int verloren = Int32.Parse(statistiekenThuisteam[3]) + 1;
                    int gewonnen = Int32.Parse(statistiekenUitteam[1]) + 1;
                    int punten = Int32.Parse(statistiekenUitteam[7]) + 3;

                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Verloren = '{verloren}' WHERE Team = '{thuisteam}' ;";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();

                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Gewonnen = '{gewonnen}', Punten = '{punten}' WHERE Team = '{uitteam}' ;";

                    insertCommandStatistiekenUitTeam2.ExecuteReader();
                }

                db.Close();
            }
        }


        public static void DeleteWedstrijdUitslag(string thuisteam, string uitteam, int thuisScore, int uitScore, int ID, string datum)
        {
            int uitslagIndex = thuisScore - uitScore;

            //verbinden met database  
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                //doelpunten verwijderen uit de database
                SqliteCommand insertCommandDoelpunten = new SqliteCommand();
                insertCommandDoelpunten.Connection = db;

                insertCommandDoelpunten.CommandText = $"DELETE FROM Doelpunt WHERE WedstrijdID = '{ID}';";

                insertCommandDoelpunten.ExecuteReader();

                //wedstrijduitslag verwijderen uit de database
                SqliteCommand insertCommandWedstrijduitslag = new SqliteCommand();
                insertCommandWedstrijduitslag.Connection = db;

                insertCommandWedstrijduitslag.CommandText = $"DELETE FROM WedstrijdUitslag WHERE ID = '{ID}';";

                insertCommandWedstrijduitslag.ExecuteReader();

                //statistieken per team ophalen zodat ze kunnen worden bijgewerkt
                List<string> statistiekenThuisteam = GetTeamstatistieken(thuisteam);
                List<string> statistiekenUitteam = GetTeamstatistieken(uitteam);

                //strings uit de lijst updaten
                int thuisTeamGespeeld = Int32.Parse(statistiekenThuisteam[0]) - 1;
                int thuisTeamDoelpuntenVoor = Int32.Parse(statistiekenThuisteam[4]) - thuisScore;
                int thuisTeamDoelpuntenTegen = Int32.Parse(statistiekenThuisteam[5]) - uitScore;
                int thuisTeamDoelsaldo = Int32.Parse(statistiekenThuisteam[6]) - (thuisScore - uitScore);

                int uitTeamGespeeld = Int32.Parse(statistiekenUitteam[0]) - 1;
                int uitTeamDoelpuntenVoor = Int32.Parse(statistiekenUitteam[4]) - uitScore;
                int uitTeamDoelpuntenTegen = Int32.Parse(statistiekenUitteam[5]) - thuisScore;
                int uitTeamDoelsaldo = Int32.Parse(statistiekenUitteam[6]) - (uitScore - thuisScore);

                //deze waarden updaten
                SqliteCommand insertCommandStatistiekenThuisTeam1 = new SqliteCommand();
                insertCommandStatistiekenThuisTeam1.Connection = db;

                insertCommandStatistiekenThuisTeam1.CommandText = $"UPDATE Teamstatistieken SET Gespeeld = '{thuisTeamGespeeld}', DoelpuntenVoor = '{thuisTeamDoelpuntenVoor}', DoelpuntenTegen = '{thuisTeamDoelpuntenTegen}', Doelsaldo = '{thuisTeamDoelsaldo}' WHERE Team = '{thuisteam}';";

                insertCommandStatistiekenThuisTeam1.ExecuteReader();


                SqliteCommand insertCommandStatistiekenUitTeam1 = new SqliteCommand();
                insertCommandStatistiekenUitTeam1.Connection = db;

                insertCommandStatistiekenUitTeam1.CommandText = $"UPDATE Teamstatistieken SET Gespeeld = '{uitTeamGespeeld}', DoelpuntenVoor = '{uitTeamDoelpuntenVoor}', DoelpuntenTegen = '{uitTeamDoelpuntenTegen}', Doelsaldo = '{uitTeamDoelsaldo}' WHERE Team = '{uitteam}';";

                insertCommandStatistiekenUitTeam1.ExecuteReader();


                // winst, gelijk of verlies bepalen en invoeren in de table teamstatistieken (> 0 = winst thuisteam, 0 = gelijk, <0 = verlies)
                if (uitslagIndex > 0)
                {

                    int gewonnen = Int32.Parse(statistiekenThuisteam[1]) - 1;
                    int verloren = Int32.Parse(statistiekenUitteam[3]) - 1;
                    int punten = Int32.Parse(statistiekenThuisteam[7]) - 3;

                    //thuisteam bijwerken
                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Gewonnen = '{gewonnen}', Punten = '{punten}' WHERE Team = '{thuisteam}';";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();

                    //uitteam bijwerken
                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Verloren = '{verloren}' WHERE Team = '{uitteam}';";

                    insertCommandStatistiekenUitTeam2.ExecuteReader();

                }
                else if (uitslagIndex == 0)
                {

                    int gelijk = Int32.Parse(statistiekenThuisteam[2]) - 1;
                    int gelijk2 = Int32.Parse(statistiekenUitteam[2]) - 1;
                    int puntenThuis = Int32.Parse(statistiekenThuisteam[7]) - 1;
                    int puntenUit = Int32.Parse(statistiekenUitteam[7]) - 1;

                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Gelijk = '{gelijk}', Punten = '{puntenThuis}' WHERE Team = '{thuisteam}' ;";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();


                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Gelijk = '{gelijk2}', Punten = '{puntenUit}' WHERE Team = '{uitteam}' ;";

                    insertCommandStatistiekenUitTeam2.ExecuteReader();
                }
                else
                {
                    int verloren = Int32.Parse(statistiekenThuisteam[3]) - 1;
                    int gewonnen = Int32.Parse(statistiekenUitteam[1]) - 1;
                    int punten = Int32.Parse(statistiekenUitteam[7]) - 3;

                    SqliteCommand insertCommandStatistiekenThuisTeam2 = new SqliteCommand();
                    insertCommandStatistiekenThuisTeam2.Connection = db;

                    insertCommandStatistiekenThuisTeam2.CommandText = $"UPDATE Teamstatistieken SET Verloren = '{verloren}' WHERE Team = '{thuisteam}' ;";

                    insertCommandStatistiekenThuisTeam2.ExecuteReader();

                    SqliteCommand insertCommandStatistiekenUitTeam2 = new SqliteCommand();
                    insertCommandStatistiekenUitTeam2.Connection = db;

                    insertCommandStatistiekenUitTeam2.CommandText = $"UPDATE Teamstatistieken SET Gewonnen = '{gewonnen}', Punten = '{punten}' WHERE Team = '{uitteam}' ;";

                    insertCommandStatistiekenUitTeam2.ExecuteReader();
                }

                db.Close();
            }
        }

        public static List<string> GetTeamstatistieken(string team)
        {
            List<string> wedstrijdstatistieken = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * FROM Teamstatistieken WHERE Team ='{team}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    
                    for (int i = 0; i < 9; i++)
                    {
                        wedstrijdstatistieken.Add(query.GetString(i));
                    }
                   
                }

                db.Close();
            }

            return wedstrijdstatistieken;
        }

        public static List<TeamStatistieken> GetStandCompetitie(string team)
        {
            List<TeamStatistieken> stand = new List<TeamStatistieken>();
            string competitie = "";

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                // naam van de competitie van het team ophalen
                SqliteCommand selectCommandCompetitie = new SqliteCommand
                    ($"SELECT Competitie FROM Team WHERE Naam ='{team}'", db);

                SqliteDataReader query = selectCommandCompetitie.ExecuteReader();

                while (query.Read())
                {
                    competitie = query.GetString(0);
                }

                //teams uit de competitie ophalen
                List<string> teams = GetTeams(competitie);

                //statistieken voor elk team in een collectie zetten              
                foreach(string teamnaam in teams)
                {
                    SqliteCommand selectCommandStatistieken = new SqliteCommand
                   ($"SELECT * FROM Teamstatistieken WHERE Team ='{teamnaam}'", db);

                    query = selectCommandStatistieken.ExecuteReader();

                    while (query.Read())
                    {
                        TeamStatistieken statistieken = new TeamStatistieken {gespeeld = Int32.Parse(query.GetString(0)), gewonnen = Int32.Parse(query.GetString(1)), gelijk = Int32.Parse(query.GetString(2)), verloren = Int32.Parse(query.GetString(3)), doelpuntenVoor = Int32.Parse(query.GetString(4)), doelpuntenTegen = Int32.Parse(query.GetString(5)), doelsaldo = Int32.Parse(query.GetString(6)), punten = Int32.Parse(query.GetString(7)), team = query.GetString(8) };
                        stand.Add(statistieken);
                    }
                }

                db.Close();
            }

            return stand;
        }

        public static List<Wedstrijduitslag> GetWedstrijduitslagen(string team)
        {
            List<Wedstrijduitslag> wedstrijduitslagen = new List<Wedstrijduitslag>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * FROM WedstrijdUitslag WHERE ThuisTeam ='{team}' OR UitTeam ='{team}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                
                while (query.Read())
                {
                    wedstrijduitslagen.Add(new Wedstrijduitslag { thuisTeam = query.GetString(0), uitTeam = query.GetString(1), scoreUit = Int32.Parse(query.GetString(2)), scoreThuis = Int32.Parse(query.GetString(3)), wedstrijdUitslagID = Int32.Parse(query.GetString(4)), datum = query.GetString(5) });
                                          
                }

                db.Close();
            }
            return wedstrijduitslagen;
        }

        

        public static void AddDoelpunt(string spelerID, string spelerNaam, string minuut, string wedstrijdID, string team)
        {
            
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"INSERT INTO Doelpunt (spelerID, spelerNaam, minuut, wedstrijdID, Team) VALUES ('{spelerID}', '{spelerNaam}', '{minuut}', '{wedstrijdID}', '{team}');";

                insertCommand.ExecuteReader();


                db.Close();
            }
        }

        public static List<Doelpunt> getDoelpuntenWedstrijd(int wedstrijdID)
        {
            List<Doelpunt> doelpunten = new List<Doelpunt>();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT spelerNaam, Minuut, Team FROM Doelpunt WHERE WedstrijdID ='{wedstrijdID}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    doelpunten.Add(new Doelpunt { speler = query.GetString(0), minuut = Int32.Parse(query.GetString(1)), team = query.GetString(2) });
                }

                db.Close();
            }

            return doelpunten;
        }

        public static List<Doelpunt> getDoelpuntenSpeler( int spelerID)
        {
            List<Doelpunt> doelpunten = new List<Doelpunt>();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT SpelerID, Minuut, Team FROM Doelpunt WHERE SpelerID ='{spelerID}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    doelpunten.Add(new Doelpunt { speler = query.GetString(0), minuut = Int32.Parse(query.GetString(1)), team = query.GetString(2) });
                }

                db.Close();
            }

            return doelpunten;
        }

        public static Wedstrijduitslag GetWedstrijduitslag(string ID)
        {
            Wedstrijduitslag uitslag = new Wedstrijduitslag();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teamManager.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * FROM WedstrijdUitslag WHERE ID = '{ID}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    uitslag = new Wedstrijduitslag { thuisTeam = query.GetString(0), uitTeam = query.GetString(1), scoreUit = Int32.Parse(query.GetString(2)), scoreThuis = Int32.Parse(query.GetString(3)), wedstrijdUitslagID = Int32.Parse(query.GetString(4)), datum = query.GetString(5) };
                }

                db.Close();
            }
            return uitslag;
        }

    }
}
