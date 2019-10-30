using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6TP2ClassLibrary
{
    public class Personne
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private string firstname;
        private string lastname;
        private string address;
        private int age;
        #endregion

        #region Properties
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Personne()
        {

        }

        public Personne(string firstname, string lastname) : this()
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public Personne(string firstname, string lastname, string address, int age) : this(firstname, lastname)
        {
            this.address = address;
            this.age = age;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public string Info()
        {
            return firstname + " " + lastname + ", " + age + " ans, habite " + address;
        }
        #endregion

        #region Events
        #endregion


    }
}
