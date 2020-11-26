using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    public class Ecole
    {
        public string NomEcole { get; set; }
        public string Localisation { get; set; }
        public string BoitePostale { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }

        public Ecole()
        {

        }

        public Ecole(string nomEcole, string localisation, string boitePostale,
                 string contact, string email, string logo)
        {
            NomEcole = nomEcole;
            Localisation = localisation;
            BoitePostale = boitePostale;
            Contact = contact;
            Email = email;
            Logo = logo;
        }
    }


}



