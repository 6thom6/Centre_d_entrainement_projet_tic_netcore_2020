using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;

namespace DAL.Repository
{
   public  class ChevalRepository : IChevalRepository
    {
        private  SqlConnection _connection;

        public ChevalRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
            //_connection = new SqlConnection(@"Data Source = MSI; Initial Catalog = DB_entrainement; Integrated Security = True;");
        }
        public List<Cheval> Get()
        {
            List<Cheval> GetAllChevaux = new List<Cheval>();

                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM CHEVAL",_connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetAllChevaux.Add(
                            new Cheval
                            { //champs en rouge = db
                                Id_Cheval = (int)reader["Id_Cheval"],
                                Nom_cheval = (string)reader["Nom_cheval"],
                                Pere_Cheval = (string)reader["Pere_Cheval"],
                                Mere_Cheval = (string)reader["Mere_Cheval"],
                                Sortie_Provisoire = reader["Sortie_Provisoire"] is DBNull ? null : (string)reader["Sortie_Provisoire"],
                                Raison_Sortie = reader["Raison_Sortie"] is DBNull ? null : (string)reader["Raison_Sortie"],
                                Id_Proprietaire = (int)reader["Id_Proprietaire"],
                                Id_Soins = reader["Id_Soins"] == DBNull.Value ? null : (int?)reader["Id_Soins"],
                                Poids = reader["Poids"] == DBNull.Value ? null : (int?)reader["Poids"],
                                Race = reader["Race"].ToString(),
                                Age = (int)reader["Age"],


                            }
                            );  ;
                    }
                }

            _connection.Close();
            return GetAllChevaux;
        }
        public Cheval GetById(int idAChercher)
        {
            Cheval  GetCheval = new Cheval();

            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM CHEVAL where ID_Cheval = @idCherch",_connection);
            command.Parameters.AddWithValue("idCherch", idAChercher);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    GetCheval = new Cheval()
                    {
                        Id_Cheval = (int)reader["Id_Cheval"],
                        Nom_cheval = (string)reader["Nom_cheval"],
                        Pere_Cheval = (string)reader["Pere_Cheval"],
                        Mere_Cheval = reader["Mere_Cheval"] is DBNull ? null : (string)reader["Mere_Cheval"],
                        Sortie_Provisoire = reader["Sortie_Provisoire"] is DBNull ? null : (string)reader["Sortie_Provisoire"],
                        Raison_Sortie = (string)reader["Raison_Sortie"],
                        Id_Proprietaire = (int)reader["Id_Proprietaire"],
                        Id_Soins = reader["Id_Soins"] == DBNull.Value ? null : (int?)reader["Id_Soins"],
                        Poids = reader["Poids"] == DBNull.Value ? null : (int?)reader["Poids"],
                        Race = reader["Race"].ToString(),
                        Age = (int)reader["Age"],
                    };
                           
                }
                _connection.Close();
                return GetCheval;
            }
        }

        public void Delete(int idADelete)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM CHEVAL where Id = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();

                _connection.Close();
            }
        }

        public void Create(Cheval NouveauCheval)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO CHEVAL (Nom_cheval, Pere_Cheval, Mere_Cheval," + //les champs de la table
                                                                        "Sortie_Provisoire, Raison_Sortie," +
                                                                        "Id_Proprietaire,Id_Soins,Poids,Race,Age," +
                                                                        "Alimentation,Complement_Alimentation)" +

                                                     "VALUES            (@Nom_Cheval, @Pere_Cheval, @Mere_Cheval," + //les champs a rentrer
                                                                        "@Sortie_Provisoire, @raison_sortieprovisoire, " +
                                                                        "@Id_Proprietaire, @Id_Soins, @Poids, @Race, @Age," +
                                                                        "@Alimentation,@Complement_Alimentation )");

                command.Parameters.AddWithValue("Nom_Cheval", NouveauCheval.Nom_cheval);
                command.Parameters.AddWithValue("Pere_Cheval", NouveauCheval.Pere_Cheval);
                command.Parameters.AddWithValue("Mere_Cheval", NouveauCheval.Mere_Cheval);
                command.Parameters.AddWithValue("Sortie_Provisoire", NouveauCheval.Sortie_Provisoire);
                command.Parameters.AddWithValue("Raison_Sortie", NouveauCheval.Raison_Sortie);
                command.Parameters.AddWithValue("Id_Proprietaire", NouveauCheval.Id_Proprietaire);
                command.Parameters.AddWithValue("Id_Soins", NouveauCheval.Id_Soins);
                command.Parameters.AddWithValue("Poids", NouveauCheval.Poids);
                command.Parameters.AddWithValue("Race", NouveauCheval.Race);
                command.Parameters.AddWithValue("Age", NouveauCheval.Age);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }


        public void Update(Cheval ChevalAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE CHEVAL SET Nom_cheval= @Nom_Cheval, " +
                                                                       "Pere_Cheval= @Pere_Cheval, " +
                                                                       "Mere_Cheval=@Mere_Cheval" +
                                                                       "Sortie_Provisoire = @Sortie_Provisoire, " +
                                                                       "Raison_Sortie = @Raison_Sortie" + 
                                                                       "Id_Proprietaire = @Id_Proprietaire, " +
                                                                       "Id_Soins = @Id_soins, " +
                                                                       "Poids = @Poids, " +
                                                                       "Race = @Race" +
                                                                       "Age = @Age " + 

                                                     "WHERE ID_Cheval = @id_cheval");

                command.Parameters.AddWithValue("Id_Cheval", ChevalAModifier.Id_Cheval);
                command.Parameters.AddWithValue("Nom_Cheval", ChevalAModifier.Nom_cheval);
                command.Parameters.AddWithValue("Pere_Cheval", ChevalAModifier.Pere_Cheval);
                command.Parameters.AddWithValue("Mere_Cheval", ChevalAModifier.Mere_Cheval);
                command.Parameters.AddWithValue("Sortie_Provisoire", ChevalAModifier.Sortie_Provisoire);
                command.Parameters.AddWithValue("Raison_Sortie", ChevalAModifier.Raison_Sortie);
                command.Parameters.AddWithValue("Id_proprietaire", ChevalAModifier.Id_Proprietaire);
                command.Parameters.AddWithValue("Id_soins", ChevalAModifier.Id_Soins);
                command.Parameters.AddWithValue("Poids", ChevalAModifier.Poids);
                command.Parameters.AddWithValue("Race", ChevalAModifier.Race);
                command.Parameters.AddWithValue("Age", ChevalAModifier.Age);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }


    }
}
