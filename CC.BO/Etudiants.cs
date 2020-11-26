using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    [Serializable]
    public class Etudiants
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public string LieuxNaissance { get; set; }
        public string Identifiant { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Sexe { get; set; }

        public Etudiants()//Pour serialisation
        {

        }

        public Etudiants(string nom, string prenom, string dateNaissance, string lieuxNaissance, string identifiant,
                string contact, string email, string sexe)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            LieuxNaissance = lieuxNaissance;
            Identifiant = identifiant;
            Contact = contact;
            Email = email;
            Sexe = sexe;
        }

        public override bool Equals(object obj)
        {
            return obj is Etudiants etudiants &&
                   Identifiant == etudiants.Identifiant;
        }

        public override int GetHashCode()
        {
            return -574969646 + EqualityComparer<string>.Default.GetHashCode(Identifiant);
        }


    }
}
