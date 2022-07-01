using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Services
{
    public class PersonneService
    {
        public string ConnectionStringSSMS
        {
            get { return "server=DESKTOP-4IKLENS;database=ExoTache;integrated security=true"; }
        }
        public IEnumerable<Personne> GetAll()
        {
            List<Personne> Personnes = new List<Personne>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = "SELECT * FROM Personne";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Personne PersonneToAdd = new Personne()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"]
                    };
                    Personnes.Add(PersonneToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Personnes;

        }

        public Personne GetId(int idchercher)
        {
            Personne personnechercher;
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);
                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);
                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Personne where id=@id";
                commande.Parameters.AddWithValue("id", idchercher);
                SqlDataReader reader = commande.ExecuteReader();
                if (reader.Read())
                {
                    personnechercher = new Personne()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"]
                    };
                }
                else return null;
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return personnechercher;
        }

        public int AddPersonne(Personne personneAAjouter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Personne (Nom,Prenom) VALUES(@Nom,@Prenom)";
                command.Parameters.AddWithValue("Nom", personneAAjouter.Nom);
                command.Parameters.AddWithValue("Prenom",personneAAjouter.Prenom);
                return command.ExecuteNonQuery();
            }
        }
        public int DeletePersonne(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Personne WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                return command.ExecuteNonQuery();
            }
        }
        public void UpdatePersonne(Personne personneAModif)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = "UPDATE Personne SET Nom = @Nom, Prenom = @Prenom WHERE Id = @id";
                commande.Parameters.AddWithValue("Nom", personneAModif.Nom);
                commande.Parameters.AddWithValue("Prenom", personneAModif.Prenom);
                commande.Parameters.AddWithValue("Id", personneAModif.Id);
                commande.ExecuteNonQuery();
            }
        }
    }
}
