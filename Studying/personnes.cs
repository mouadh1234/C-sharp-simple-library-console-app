using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Studying
{
    internal class personnes
    {
        public static void menuPersonne()
        {
           // Console.Clear();
            Console.WriteLine("-----------------------gestion des utilisateurs-----------------------");
            Console.WriteLine("1:Ajouter utilisateur");
            Console.WriteLine("2:afficher la liste des utilisateur");
            Console.WriteLine("3:modifier utilisateur");
            Console.WriteLine("4:Supprimer utilisateur");
            Console.WriteLine("5:menu principal");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("entrer le choix");

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1: Console.Clear(); ajouterPersonne(); menuPersonne(); break;
                case 2: Console.Clear(); afficherPersonnes(); menuPersonne(); break;
                case 3: Console.Clear(); modifierPersonne(); afficherPersonnes(); menuPersonne(); break;
                case 4: Console.Clear(); supprimerPersonne(); afficherPersonnes(); menuPersonne(); break;
                case 5: Console.Clear(); biblio.bibliotheque(); break;
                default: Console.WriteLine("veuillez entrer choix valide"); menuPersonne(); break;
            }
        }
        public static void ajouterPersonne()
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
                Console.WriteLine("entrez login");
                String loginUser = Console.ReadLine();
                Console.WriteLine("entrez le mot de passe");
                String passwordUser = Console.ReadLine();
                Console.WriteLine("entrez email");
                String emailUser = Console.ReadLine();
                String insertQuery = "INSERT INTO UTILISATEURS(loginUser,passwordUser,emailUser) VALUES('" + loginUser + "','" + passwordUser + "','" + emailUser + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Console.Clear();
                Console.WriteLine("utilisateur ajouter avec succes");
                menuPersonne();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void afficherPersonnes()
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

                String showQuery = "SELECT * FROM UTILISATEURS";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("userId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("loginUser: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("passwordUser: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("emailUser: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }
                dataReader.Close();
                sqlConnection.Close();
                menuPersonne();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void modifierPersonne()
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

                String showQuery = "SELECT * FROM UTILISATEURS";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("userId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("loginUser: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("passwordUser: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("emailUser: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }

                dataReader.Close();
                Console.WriteLine("entrez id utilisateur a modifier");
                int lId;
                bool test = int.TryParse(Console.ReadLine(), out lId);
                while (test == false)
                {
                    Console.WriteLine("erreur veuillez entrer un id valid");
                    Console.WriteLine("entrez id utilisateur a modifier");
                    test = int.TryParse(Console.ReadLine(), out lId);

                }
               
                Console.WriteLine("loginUser");
                String logUser = Console.ReadLine();
                Console.WriteLine("passwordUser");
                String passUser = Console.ReadLine();
                Console.WriteLine("emailUser");
                String emUser = Console.ReadLine();
                String updateQuery = "UPDATE Utilisateurs SET loginUser = '" + logUser + "', passwordUser = '" + passUser + "', emailUser = '" + emUser + "' WHERE userId = " + lId + " ";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                Console.Clear();
                Console.WriteLine("utilisateur modifier");
                menuPersonne();

                Console.WriteLine(lId);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void supprimerPersonne()
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
                String showQuery = "SELECT * FROM UTILISATEURS";
                SqlCommand showCommand = new SqlCommand(showQuery, sqlConnection);
                SqlDataReader dataReader = showCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("userId: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("loginUser: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("passwordUser: " + dataReader.GetValue(2).ToString());
                    Console.WriteLine("emailUser: " + dataReader.GetValue(3).ToString());
                    Console.WriteLine("----------------------------");

                }

                dataReader.Close();
                Console.WriteLine("entrez id utilisateur a supprimer");
                int lId;
                bool test = int.TryParse(Console.ReadLine(), out lId);
                while (test == false)
                {
                    Console.WriteLine("erreur veuillez entrer un id valid");
                    Console.WriteLine("entrez id utilisateur a supprimer");
                    test = int.TryParse(Console.ReadLine(), out lId);

                }

                String updateQuery = "DELETE FROM Utilisateurs WHERE userId = " + lId + " ";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.Clear();

                Console.WriteLine("utilisateur supprimer avec succes");
                sqlConnection.Close();
                menuPersonne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
