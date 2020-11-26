using CC01.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.DAL
{
    public class EtudiantDAO
    {
        private static List<Etudiants> etudiants;
        private const string FILE_NAME = @"etudiants.json";
        private readonly string dbFolder;
        private FileInfo file;
        private Etudiants etudiant;

        public EtudiantDAO(string dbFolder)
        {
            this.dbFolder = dbFolder;

            file = new FileInfo(Path.Combine(this.dbFolder, FILE_NAME));
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            if (!file.Exists)
            {
                file.Create().Close();
                file.Refresh();
            }
            if (file.Length > 0)
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string json = sr.ReadToEnd();
                    etudiants = JsonConvert.DeserializeObject<List<Etudiants>>(json);
                }
            }
            if (etudiants == null)
            {
                etudiants = new List<Etudiants>();
            }


        }

        public Etudiants Get()
        {
            return etudiant;
        }

        public void Set(Etudiants oldEtudiants, Etudiants newEtudiants)
        {
            var oldIndex = etudiants.IndexOf(oldEtudiants);
            var newIndex = etudiants.IndexOf(oldEtudiants);
            if (oldIndex < 0)
                throw new KeyNotFoundException("The student doesn't exists !");
            if (newIndex >= 0 && oldIndex != newIndex)
                throw new DuplicateNameException("The student identifier already exists !");
            etudiants[oldIndex] = newEtudiants;
            Save();
        }

        public void Add(Etudiants etudiants)
        {
            var index = EtudiantDAO.etudiants.IndexOf(etudiants);
            if (index >= 0)
                throw new DuplicateNameException("The student identifier already exists !");
            EtudiantDAO.etudiants.Add(etudiants);
            Save();
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(file.FullName, false))
            {
                string json = JsonConvert.SerializeObject(etudiants);
                sw.WriteLine(json);
            }
        }

        public void Remove(Etudiants etudiants)
        {
            EtudiantDAO.etudiants.Remove(etudiants);
            Save();
        }

        public IEnumerable<Etudiants> Find()
        {
            return new List<Etudiants>(etudiants);
        }

        public IEnumerable<Etudiants> Find(Func<Etudiants, bool> predicate)
        {
            return new List<Etudiants>(etudiants.Where(predicate).ToArray());
        }
    }
}
