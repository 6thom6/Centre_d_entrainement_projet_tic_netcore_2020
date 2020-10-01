﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProprietaireCheval
    {
        public string Nom_Proprietaire { get; set; }
        public DateTime Date_Arrivee { get; set; }
        public string NomCheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string SortieProvisoire { get; set; }
        public string RaisonSortie { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
    }
}