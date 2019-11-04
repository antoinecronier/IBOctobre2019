using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18TP1ClassLibrary.Entities
{
    public class Employee
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private long employeeId;
        private string firstname;
        private string lastname;
        private DateTime dateOfBirth;
        private string city;
        private float salary;
        private string function;
        private Service department;
        #endregion

        #region Properties
        public long EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public Service Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Function
        {
            get { return function; }
            set { function = value; }
        }

        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
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
        public Employee()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion


    }
}
