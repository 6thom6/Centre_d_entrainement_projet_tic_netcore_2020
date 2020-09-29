using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;

namespace DAL.Repository
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private static Connection _connection;

        public VaccinationRepository(Connection connection)
        {
            _connection = connection;
        }
        public VaccinationRepository(): this(_connection) { }
        public IEnumerable<Vaccination> GetallVaccination()
        {
            Command command = new Command("SELECT * FROM Vaccination");
            return _connection.ExecuteReader(command, dr => dr.VaccinationToDal());
        }
        public Vaccination GetById(int id)
        {
            Command command = new Command("SELECT * FROM Vaccination where Id_vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.VaccinationToDal()).SingleOrDefault();

        }
        public int Create(Vaccination vaccination)
        {

            Command command = new Command("CreateVaccination", true);
                command.AddParameter("nom_vaccin", vaccination.Nom_Vaccin);
                command.AddParameter("delai_indisponibilite", vaccination.Delai_Indisponibilite);

            return _connection.ExecuteNonQuery(command);

            
        }
        public int Update(int id, Vaccination vaccination)
        {
     
                Command command = new Command("UPDATE Vaccination SET  " +
                                                                            "Nom_Vaccin = @Nom_Vaccin, " +
                                                                            "Delai_Indisponibilite= @Delai_Indisponibilite " +
                                                                            "where Id_Vaccination = Id_Vaccination");



                command.AddParameter("Id_Vaccination",id);
                command.AddParameter("Nom_Vaccin", vaccination.Nom_Vaccin);
                command.AddParameter("Delai_Indisponibilite", vaccination.Delai_Indisponibilite);

            return _connection.ExecuteNonQuery(command);
           
        }
        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM Vaccination where Id_Vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);
        }



        public string GetNomChevalVaccin(int id)
        {
            Command command = new Command(" select c.Nom_cheval from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where V.Id_vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();

        }
        public string GetRaceChevalVaccin(int id)
        {
            Command command = new Command("select c.Race from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where V.Id_vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Race"]).FirstOrDefault();

        }
        public int GetAgeChevalParVaccin(int id)
        {
            Command command = new Command(" select c.Age from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where V.Id_vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Age"]).FirstOrDefault();

        }
        public string GetSexeChevalVaccin(int id)
        {
            Command command = new Command(" select c.Sexe from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where V.Id_vaccination = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();

        }


    }
}
