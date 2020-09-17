﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Soins
    {
        public int? Id_Soins { get; set; }
        public int Id_Cheval { get; set; }
        public int? Id_Employe { get; set; }
        public string Alimentation { get; set; }
        public string Complement_Alimentation { get; set; }
        public DateTime? Marechal { get; set; }
        public DateTime? Vermifuge { get; set; }
        public string Note_Libre { get; set; }
        public string Type_de_soin { get; set; }
        public string durree_indisponibilite { get; set; }
        public DateTime? date_de_soin { get; set; }


    }
}
