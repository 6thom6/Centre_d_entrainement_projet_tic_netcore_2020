using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ChevalCourse
    {
        public string Nom_Cheval { get; set; }
        public string Race { get; set; }
        public string Sexe { get; set; }
        public int Age { get; set; }
        public int Id_Courses { get; set; }
        public int Distance { get; set; }
        public string Hippodrome { get; set; }
        public string Jockey { get; set; }
        public string Corde { get; set; }
        public string Discipline { get; set; }
        public string Terrain { get; set; }
        public string Avis { get; set; }
        public double Poids_De_Course { get; set; }
        public DateTime Date_Courses { get; set; }
    }
}
