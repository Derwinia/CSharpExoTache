using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class TacheService
    {
        public string ConnectionStringSSMS
        {
            get { return "server=DESKTOP-4IKLENS;database=ExoTache;integrated security=true"; }
        }
        public IEnumerable<Tache> GetAll()
        {
            List<Tache> Taches = new List<Tache>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = "SELECT * FROM Tache";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Tache TacheToAdd = new Tache()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Categorie = (int)reader["Categorie"],
                        Description = (string)reader["Description"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateFinPrevu = (DateTime)reader["DateFinPrevu"],
                        DateFinReel = reader["DateFinReel"] as DateTime? ?? null,
                        PersonneAssignee = (int)reader["PersonneAssignee"],
                    };
                    Taches.Add(TacheToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Taches;

        }

        public IEnumerable<Tache> GetbyCategorie(int categorie)
        {
            List<Tache> Taches = new List<Tache>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Tache where categorie = {categorie}";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Tache TacheToAdd = new Tache()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Categorie = (int)reader["Categorie"],
                        Description = (string)reader["Description"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateFinPrevu = (DateTime)reader["DateFinPrevu"],
                        DateFinReel = reader["DateFinReel"] as DateTime? ?? null,
                        PersonneAssignee = (int)reader["PersonneAssignee"],
                    };
                    Taches.Add(TacheToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Taches;
        }
        public IEnumerable<Tache> GetbyPersonne(int idPersonneRechercher)
        {
            List<Tache> Taches = new List<Tache>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Tache where PersonneAssignee = {idPersonneRechercher}";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Tache TacheToAdd = new Tache()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Categorie = (int)reader["Categorie"],
                        Description = (string)reader["Description"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateFinPrevu = (DateTime)reader["DateFinPrevu"],
                        DateFinReel = reader["DateFinReel"] as DateTime? ?? null,
                        PersonneAssignee = (int)reader["PersonneAssignee"],
                    };
                    Taches.Add(TacheToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Taches;
        }
        public IEnumerable<Tache> GetbyTacheNonFini()
        {
            List<Tache> Taches = new List<Tache>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);

                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);

                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Tache where DateFinReel IS NULL";
                SqlDataReader reader = commande.ExecuteReader();
                while (reader.Read())
                {
                    Tache TacheToAdd = new Tache()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Categorie = (int)reader["Categorie"],
                        Description = (string)reader["Description"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateFinPrevu = (DateTime)reader["DateFinPrevu"],
                        DateFinReel = reader["DateFinReel"] as DateTime? ?? null,
                        PersonneAssignee = (int)reader["PersonneAssignee"],
                    };
                    Taches.Add(TacheToAdd);
                }
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Taches;
        }

        public Tache GetId(int idchercher)
        {
            Tache Tachechercher;
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                Console.WriteLine("Connection crée : " + connection.State);
                connection.Open();
                Console.WriteLine("Connection ouverte : " + connection.State);
                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = $"SELECT * FROM Tache where id=@id";
                commande.Parameters.AddWithValue("id", idchercher);
                SqlDataReader reader = commande.ExecuteReader();
                if (reader.Read())
                {
                    Tachechercher = new Tache()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Categorie = (int)reader["Categorie"],
                        Description = (string)reader["Description"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateFinPrevu = (DateTime)reader["DateFinPrevu"],
                        DateFinReel = reader["DateFinReel"] as DateTime? ?? null,
                        PersonneAssignee = (int)reader["PersonneAssignee"],
                    };
                }
                else return null;
                connection.Close();
                Console.WriteLine("Connection fermée : " + connection.State);
            }
            return Tachechercher;
        }

        public int AddTache(Tache TacheAAjouter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Tache (Nom,Categorie,Description,DateCreation,DateFinPrevu,PersonneAssignee) VALUES(@Nom,@Categorie,@Description,@DateCreation,@DateFinPrevu,@PersonneAssignee)";
                command.Parameters.AddWithValue("Nom", TacheAAjouter.Nom);
                command.Parameters.AddWithValue("Categorie", TacheAAjouter.Categorie);
                command.Parameters.AddWithValue("Description", TacheAAjouter.Description);
                command.Parameters.AddWithValue("DateCreation", TacheAAjouter.DateCreation);
                command.Parameters.AddWithValue("DateFinPrevu", TacheAAjouter.DateFinPrevu);
                command.Parameters.AddWithValue("PersonneAssignee", TacheAAjouter.PersonneAssignee);
                return command.ExecuteNonQuery();
            }
        }
        public int DeleteTache(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Tache WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                return command.ExecuteNonQuery();
            }
        }
        public void UpdateTache(Tache TacheAModif)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSSMS))
            {
                connection.Open();
                SqlCommand commande = connection.CreateCommand();
                commande.CommandText = "UPDATE Tache SET Nom = @Nom, Categorie = @Categorie,Description = @Description,DateCreation = @DateCreation,DateFinPrevu = @DateFinPrevu,DateFinReel = @DateFinReel,PersonneAssignee = @PersonneAssignee WHERE Id = @id";
                commande.Parameters.AddWithValue("Nom", TacheAModif.Nom);
                commande.Parameters.AddWithValue("Categorie", TacheAModif.Categorie);
                commande.Parameters.AddWithValue("Description", TacheAModif.Description);
                commande.Parameters.AddWithValue("DateCreation", TacheAModif.DateCreation);
                commande.Parameters.AddWithValue("DateFinPrevu", TacheAModif.DateFinPrevu);
                commande.Parameters.AddWithValue("DateFinReel", TacheAModif.DateFinReel == null ? DBNull.Value :TacheAModif.DateFinReel) ;
                commande.Parameters.AddWithValue("PersonneAssignee", TacheAModif.PersonneAssignee);
                commande.Parameters.AddWithValue("Id", TacheAModif.Id);
                commande.ExecuteNonQuery();
            }
        }
    }
}
