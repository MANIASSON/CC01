using CC01.BO
using CC01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{
    public class EtudiantBLO
    {
        EtudiantDAO etudiantRepo;
        public EtudiantBLO(string dbFolder)
        {
            etudiantRepo = new EtudiantDAO(dbFolder);
        }

        public void CreateEtudiant(Etudiants etudiant)
        {
            etudiantRepo.Add(etudiant);
        }

        public void DeleteEtudiant(Etudiants etudiant)
        {
            etudiantRepo.Remove(etudiant);
        }

        public IEnumerable<Etudiants> GetAllEtudiant()
        {
            return etudiantRepo.Find();
        }

        public IEnumerable<Etudiants> GetByIdentifiant(string identifiant)
        {
            return etudiantRepo.Find(x => x.Identifiant == identifiant);
        }

        public IEnumerable<Etudiants> GetBy(Func<Etudiants, bool> predicate)
        {
            return etudiantRepo.Find(predicate);
        }

        public void EditEtudiants(Etudiants oldEtudiants, Etudiants newEtudiants)
        {
            etudiantRepo.Set(oldEtudiants, newEtudiants);
        }

        public Etudiants GetEtudiant()
        {
            Etudiants company = etudiantRepo.Get();
            /* if (company != null)
                 if (!string.IsNullOrEmpty(company.Logo))
                     company.Logo = Path.Combine(dbFolder, "logo", company.Logo);*/
            return company;
        }
    }
}
