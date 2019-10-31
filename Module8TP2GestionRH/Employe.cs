using Module8TP2ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8TP2GestionRH
{
    public class Employe : Personne
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int number;
        private string position;
        private double salary;
        #endregion

        #region Properties
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Employe(string firstname, string lastname, string address, int age, string position, double salary) : base(firstname,lastname,address,age)
        {
            this.position = position;
            this.salary = salary;
        }

        public Employe(Personne personne, string position, double salary) : base(personne.Firstname, personne.Lastname, personne.Address, personne.Age)
        {
            this.position = position;
            this.salary = salary;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string Info()
        {
            return base.Info() + ", " + this.position;
        }

        public void SalaryIncrease(double increase)
        {
            if (increase > 0)
            {
                this.salary += increase;
            }
        }

        public void Assignment(string assignment)
        {
            this.position = assignment;
        }
        #endregion

        #region Events
        #endregion


    }
}
