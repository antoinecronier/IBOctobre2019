﻿using Module18TP1ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if (this.Database.CreateIfNotExists())
            {
                for (int i = 0; i < 5; i++)
                {
                    Service service = new Service();
                    service.Name = "service name " + i;
                    service.Description = "service description " + i;
                    this.Services.Add(service);
                    this.SaveChanges();
                }

                Random random = new Random();
                for (int i = 0; i < 30; i++)
                {
                    Employee employee = new Employee();
                    employee.Firstname = "firstname " + i;
                    employee.Lastname = "lastname " + i % 10;
                    employee.Function = "functionbase" + i % 5;
                    employee.Salary = 200F * i;
                    employee.DateOfBirth = DateTime.Now;
                    employee.Department = this.Services.Find(random.Next(1, this.Services.Count()));
                    this.Employees.Add(employee);

                    this.SaveChanges();
                }
            }
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOptional(x => x.Department).WithMany(x => x.Employees);

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Events
        #endregion


    }
}
