using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.BO
{
    class Ecole
    {
        public string NomEcole { get; set; }
        public string Localisation { get; set; }
        public string BoitePostale { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public string Logos { get; set; }

        public Ecole()
        {

        }

        public Ecole(string nomEcole, string localisation, string boitePostale,
                 string telephone, string email, string logos)
        {
            NomEcole = nomEcole;
            Localisation = localisation;
            BoitePostale = boitePostale;
            Telephone = telephone;
            Email = email;
            Logos = logos;
        }
    }
}
