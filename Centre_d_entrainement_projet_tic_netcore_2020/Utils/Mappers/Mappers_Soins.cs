using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Soins
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Soins Dal_To_Consumme(this DAL.Models.Soins soins)
        {
            return new Models.Soins
            {
                Id_Soins = soins.Id_Soins,
                Id_Cheval = soins.Id_Cheval,
                Id_Employe = soins.Id_Employe,
                Alimentation = soins.Alimentation,
                Complement_Alimentation = soins.Complement_Alimentation,
                Marechal = soins.Marechal,
                Vermifuge = soins.Vermifuge,
                Note_Libre = soins.Note_Libre,
                Type_de_soin = soins.Type_de_soin,
                durrée_indisponibilité = soins.durrée_indisponibilité,
                date_de_soin = soins.date_de_soin,

            };

        }
        public static DAL.Models.Soins Consumme_to_dal(this Centre_d_entrainement_projet_tic_netcore_2020.Models.Soins soins)
        {
            return new DAL.Models.Soins
            {
                Id_Soins = soins.Id_Soins,
                Id_Cheval = soins.Id_Cheval,
                Id_Employe = soins.Id_Employe,
                Alimentation = soins.Alimentation,
                Complement_Alimentation = soins.Complement_Alimentation,
                Marechal = soins.Marechal,
                Vermifuge = soins.Vermifuge,
                Note_Libre = soins.Note_Libre,
                Type_de_soin = soins.Type_de_soin,
                durrée_indisponibilité = soins.durrée_indisponibilité,
                date_de_soin = soins.date_de_soin,
            };
        }
    }
}
