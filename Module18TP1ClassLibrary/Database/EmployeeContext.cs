using Module18TP1ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18TP1ClassLibrary.Database
{
    public class EmployeeContext : DbContext
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        #endregion

        #region Properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmployeeContext() : base()
        {
            if (this.Database.Exists())
            {
                this.Database.Delete();
            }

            this.Database.Create();
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
