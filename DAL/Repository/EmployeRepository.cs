using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;

namespace DAL.Repository
{
    class EmployeRepository : IEmployeRepository
    {
        public SqlConnection _connection;

        public EmployeRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        public List<Employé> GetallEmploye()
        {
            List<Employé> GetallEmploye = new List<Employé>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employé", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallEmploye.Add(
                        new Employé
                        {
                            Id_Employe = (int)reader["Id_Employe"],
                            Nom_Employe = (string)reader["Nom_Employe"],
                            Statut_Employe =  (string)reader["Statut_Employe"],
                            Employe_Embauche = reader["Employe_Embauche"] == DBNull.Value ? null : (DateTime?)reader["Employe_Embauche"]
                        }
                        );
                }
            }

            return GetallEmploye;
        }
        public Employé Get(int idAChercher)
        {
            Employé GetEmploye = new Employé();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employé where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Employé
                    {
                        Id_Employe = (int)reader["Id_Employe"],
                        Nom_Employe = (string)reader["Nom_Employe"],
                        Statut_Employe = (string)reader["Statut_Employe"],
                        Employe_Embauche = reader["Employe_Embauche"] == DBNull.Value ? null : (DateTime?)reader["Employe_Embauche"]
                    };
                        
                }
            }

            return GetEmploye;

        }
        public void Create(Employé NouvelEmploye)
        {
            using (_connection)
            {

                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Employé " +
                                                                "(Nom_Employe," + //les champs de la table
                                                                  "Statut_Employé," +
                                                                  "Employé_Embauche," +

                                                   "VALUES          (@Nom_Employe," + //les champs a rentrer
                                                                    "@Status_Employe, " +
                                                                    "@Employe_Embauche");

                command.Parameters.AddWithValue("Nom_Employe", NouvelEmploye.Nom_Employe);
                command.Parameters.AddWithValue("Status_Employe", NouvelEmploye.Statut_Employe);
                command.Parameters.AddWithValue("Employe_Embauche", NouvelEmploye.Employe_Embauche);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Employé EmployéAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Employé " +
                                                    "Id_Employe = @Id_Employe" +
                                                     "Nom_Employe = @Nom_Employe, " +
                                                     "Statut_Employe = @Status_Employe, " +
                                                     "Employe_Embauche = @Employe_Embauche" +
                                                     "where Employé Id_Employé = @Id_Employe");

                command.Parameters.AddWithValue("Id_Employe", EmployéAModifier.Id_Employe);
                command.Parameters.AddWithValue("Nom_Employe", EmployéAModifier.Nom_Employe);
                command.Parameters.AddWithValue("Status_Employe", EmployéAModifier.Statut_Employe);
                command.Parameters.AddWithValue("Employe_Embauche", EmployéAModifier.Employe_Embauche);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Employé where ID_Employe = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}

