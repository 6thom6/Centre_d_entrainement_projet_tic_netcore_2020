﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Historique
    {
        public int Id_Historique { get; set; }
        public int Id_Cheval { get; set; } 
        public string Debourage { get; set; }
        public string Pre_Entrainement { get; set; }
        public string Entraineur_Precedent { get; set; }
        public string Proprietaire_Precedent { get; set; }
        public string Elevage { get; set; }
    }
}
