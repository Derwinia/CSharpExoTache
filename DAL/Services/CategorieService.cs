using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Services
{
    public class CategorieService
    {
        public string ConnectionStringSSMS
        {
            get { return "server=DESKTOP-4IKLENS;database=ExoTache;integrated security=true"; }
        }
        public IEnumerable<Categorie> GetAll()
        {
            List<Categorie> Categories = new List<Categorie>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = "SELECT * FROM Categorie";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Categorie CategorieToAdd = new Categorie()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"]
                    };
                    Categories.Add(CategorieToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Categories;

        }

        public Categorie GetId(int idchercher)
        {
            Categorie categoriechercher;
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);
                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);
                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Categorie where id=@id";
                commande.Parameters.AddWithValue("id", idchercher);
                SqlDataReader reader = commande.ExecuteReader();
                if (reader.Read())
                {
                    categoriechercher = new Categorie()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"]
                    };
                }
                else return null;
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return categoriechercher;
        }

        public int AddCategorie(Categorie CategorieAAjouter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Categorie (Nom) VALUES(@Nom)";
                command.Parameters.AddWithValue("Nom", CategorieAAjouter.Nom);
                return command.ExecuteNonQuery();
            }
        }
        public int DeleteCategorie(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Categorie WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                return command.ExecuteNonQuery();
            }
        }
    }
}
