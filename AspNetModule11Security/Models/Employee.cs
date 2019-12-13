using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetModule11Security.Models
{
    public class Employee
    {
        private int employeeId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string lastname;

        [Required]
        [DisplayName("Nom")]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string firstname;

        [Required]
        [DisplayName("Prénom")]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [NotMapped]
        public string FullName { get { return this.Lastname + " " + this.Firstname; } }

        private ICollection<Project> projects;

        public ICollection<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public Employee()
        {
            this.projects = new List<Project>();
        }
    }
}