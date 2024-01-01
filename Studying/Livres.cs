using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Studying
{
    internal class Livres
    {
        public static void menuLivres()
        {
           // Console.Clear();
            Console.WriteLine("--------------------------gestion des livres--------------------------");
            Console.WriteLine("1:Ajouter livre");
            Console.WriteLine("2:afficher la liste des livres");
            Console.WriteLine("3:Modifier livre");
            Console.WriteLine("4:Supprimer livre");
            Console.WriteLine("5:menu principal");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("entrer le choix");

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1: Console.Clear(); ajouterLivre(); menuLivres(); break;
                case 2: Console.Clear(); afficherLivres(); menuLivres(); break;
                case 3:
                    Console.Clear(); modifierLivres(); menuLivres();
                    break;
                case 4: Console.Clear(); supprimerLivres(); afficherLivres(); menuLivres(); break;
                case 5: Console.Clear(); biblio.bibliotheque(); break;
                default: Console.Clear(); Console.WriteLine("veuillez entrer choix valide");menuLivres(); break;
            }
        }
        public static void ajouterLivre()
        {
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-TVKIK2S\SQLEXPRESS;Initial Catalog=Studying;Integrated Security=True";
           // Console.WriteLine("Hello, World!");
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
               // Console.WriteLine("connection with succed");
               //Ajouter Livre
               Console.WriteLine("Nom du livre a ajouter");
                String livreName = Console.ReadLine();
                Console.WriteLine("Auteur du livre a ajouter");
                String livreAuteur = Console.ReadLine();
                Console.WriteLine("Genre du livre a ajouter");
                String livreGenre = Console.ReadLine();
                String insertQuery = "INSERT INTO LIVRES(livreName,livreAuteur,livreGenre) VALUES('"+livreName+"','"+livreAuteur+"','"+livreGenre+"')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("livre ajouter avec succes");
          
                menuLivres();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void afficherLivres()
        {
            Console.Clear();
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-TVKIK2S\SQLEXPRESS;Initial Catalog=Studying;Integrated Security=True";
            // Console.WriteLine("Hello, World!");
            try
            {
                sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            // Console.WriteLine("connection with succed");
            //Afficher Livre
           
            String showQuery = "SELECT * FROM LIVRES";
            SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();   
            while(dataReader.Read())
                {
                    Console.WriteLine("livreId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("livreName: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("livreAuteur: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("livreGenre: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }
                dataReader.Close();
                sqlConnection.Close();

                menuLivres();
            
        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
}
        public static void modifierLivres()
        {
            Console.Clear();
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-TVKIK2S\SQLEXPRESS;Initial Catalog=Studying;Integrated Security=True";
            // Console.WriteLine("Hello, World!");
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                String showQuery = "SELECT * FROM LIVRES";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("livreId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("livreName: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("livreAuteur: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("livreGenre: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }

                dataReader.Close();

                Console.WriteLine("entrez id livre a modifier");
                int lId;
                bool test = int.TryParse(Console.ReadLine(), out lId);
                while ( test ==false)
                {
                    Console.WriteLine("error");
                    Console.WriteLine("entrez id livre a modifier");
                    test = int.TryParse(Console.ReadLine(), out lId);

                }

                            Console.WriteLine("Nom du livre");
                            String lName = Console.ReadLine();
                            Console.WriteLine("Auteur");
                            String lAuteur = Console.ReadLine();
                            Console.WriteLine("Genre");
                            String lGenre = Console.ReadLine();
                            String updateQuery = "UPDATE Livres SET livreName= '" + lName + "', livreAuteur = '" + lAuteur + "', livreGenre = '" + lGenre + "' WHERE livreId = " + lId + " ";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();

                Console.Clear();

                Console.WriteLine("livre modifier");
                    sqlConnection.Close();
                    menuLivres();
                
                Console.WriteLine(lId);
                
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void supprimerLivres()
        {
            Console.Clear();
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-TVKIK2S\SQLEXPRESS;Initial Catalog=Studying;Integrated Security=True";
            // Console.WriteLine("Hello, World!");
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                String showQuery = "SELECT * FROM LIVRES";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("livreId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("livreName: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("livreAuteur: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("livreGenre: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }

                dataReader.Close();
                Console.WriteLine("entrez id livre a supprimer");
                int lId;
                bool test = int.TryParse(Console.ReadLine(), out lId);
                while (test == false)
                {
                    Console.WriteLine("error");
                    Console.WriteLine("entrez id livre a supprimer");
                    test = int.TryParse(Console.ReadLine(), out lId);

                }

                String deleteQuery = "DELETE FROM Livres  WHERE livreId = " + lId + " ";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();

                Console.Clear();
                Console.WriteLine("livre supprimer avec succes");
                sqlConnection.Close();
                menuLivres();

                Console.WriteLine(lId);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
