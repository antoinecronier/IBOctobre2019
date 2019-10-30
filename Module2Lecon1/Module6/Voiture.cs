using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Lecon1.Module6
{
    public class Voiture
    {
        public enum CoteVolant
        {
            Droite,
            Gauche,
            Milieu
        }

        private int poids;
        private string nom;
        private string immatriculation;
        private string type;
        private string marque;
        private int nbPlace;
        private bool aUneCapote;
        private CoteVolant coteVolant1;
        
        //propfull
        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        public int Poids { get => poids; set => poids = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Immatriculation
        {
            get { return immatriculation; }
            set {
                if (value.Length != 8)
                {
                    throw new Exception("not an imat");
                }
                else
                {
                    immatriculation = value;
                }
            }
        }
        public string Type { get => type; set => type = value; }
        public string Marque { get => marque; set => marque = value; }
        public int NbPlace { get => nbPlace; set => nbPlace = value; }
        public bool AUneCapote { get => aUneCapote; set => aUneCapote = value; }
        public CoteVolant CoteVolant1 { get => coteVolant1; set => coteVolant1 = value; }

        public Voiture()
        {

        }

        /// <summary>
        /// Copy voiture to new voiture.
        /// </summary>
        /// <param name="voiture"></param>
        public Voiture(Voiture voiture)
        {
            this.poids = voiture.poids;
            this.nom = voiture.nom;
            this.immatriculation = voiture.immatriculation;
            this.type = voiture.type;
            this.marque = voiture.marque;
            this.nbPlace = voiture.nbPlace;
            this.aUneCapote = voiture.aUneCapote;
            this.coteVolant1 = voiture.coteVolant1;
        }

        public Voiture(int poids, string nom, string immatriculation, string type, string marque, int nbPlace, bool aUneCapote, CoteVolant coteVolant) 
            : this(poids, nom, immatriculation)
        {
            this.type = type;
            this.marque = marque;
            this.nbPlace = nbPlace;
            this.aUneCapote = aUneCapote;
            this.coteVolant1 = coteVolant;
        }

        public Voiture(int poids, string nom, string immatriculation) : this()
        {
            this.poids = poids;
            this.nom = nom;
            this.immatriculation = immatriculation;
        }
    }
}
