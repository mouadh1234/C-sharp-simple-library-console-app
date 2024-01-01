using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Studying
{
    internal class biblio
    {
        public static void bibliotheque()
        {
            Console.WriteLine("----------------------------Menu principal----------------------------");
            Console.WriteLine("1:menu livres");
            Console.WriteLine("2:menu utilisateurs");
            Console.WriteLine("3:quitter");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("entrer le choix");

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:Livres.menuLivres(); break;
                case 2:personnes.menuPersonne(); break;
                case 3: Environment.Exit(0); break;
                default: Console.WriteLine("veuillez entrer choix valide" +
                    "");bibliotheque(); break;
            }
        }
        public static void acceuil()
        {
            Console.WriteLine("-------------------bienvenue dans notre bibliotheque-------------------");
            Console.WriteLine("1:authentification");
            Console.WriteLine("2:creer compte");
            Console.WriteLine("3:quitter");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("entrer le choix");

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1: Console.Clear(); authentification(); break;
                case 2: Console.Clear(); personnes.ajouterPersonne(); bibliotheque(); break;
                case 3: Environment.Exit(0); break;
                default:
                    Console.WriteLine("veuillez entrer choix valide" +
                    ""); bibliotheque(); break;
            }
        }
        public static void authentification()
        {
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-TVKIK2S\SQLEXPRESS;Initial Catalog=Studying;Integrated Security=True";
            // Console.WriteLine("Hello, World!");
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                // Console.WriteLine("connection with succed");
                //Afficher Livre
                Console.WriteLine("-----------------------Espace authentification------------------------");

                Console.WriteLine("login");
                String log = Console.ReadLine().ToString();
                Console.WriteLine("password");
                String psd = Console.ReadLine().ToString();

                String showQuery = "SELECT * FROM UTILISATEURS WHERE loginUser='"+log+"' and passwordUser='"+psd+"'"+"";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                int idu;
                while (dataReader.Read())
                {

                    while(string.IsNullOrEmpty(dataReader.GetValue(0).ToString())==true)
                    {
                        authentification();
                        
                    }
                    Console.Clear();
                    bibliotheque();

                }
                
                dataReader.Close();
                sqlConnection.Close();
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
