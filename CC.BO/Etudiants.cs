using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.BO
{
    public class Etudiants
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public string Nationalite { get; set; }
        public string Identifiant { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Etudiants()//Pour serialisation
        {

        }

        public Etudiants(string nom, string prenom, string dateNaissance, string nationalite, string identifiant,
                string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Nationalite = nationalite;
            Identifiant = identifiant;
            Telephone = telephone;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is Etudiants etudiants &&
                   Identifiant == etudiants.Identifiant;
        }

        public override int GetHashCode()
        {
            return 574969646 + EqualityComparer<string>.Default.GetHashCode(Identifiant);
        }

       
    }
}
