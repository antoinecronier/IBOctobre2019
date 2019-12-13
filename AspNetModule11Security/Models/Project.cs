using AspNetModule11Security.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetModule11Security.Models
{
    public class Project
    {
        private int projectId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private string title;

        [Required]
        [DisplayName("Intitulé")]
        [RegularExpression(@"^[A-Z]{2}\d{5}$")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime startDate;

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de début")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateValidators("Now")]
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime deliveryDate;

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de livraison")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateValidators("StartDate",DateValidators.DateValidatorMode.OverOrEqualToProperty)]
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        private int nbDays;

        [DisplayName("Nombre de jour")]
        [DateIntervalValidators("StartDate", "DeliveryDate")]
        public int NbDays
        {
            get { return nbDays; }
            set { nbDays = value; }
        }

        private string description;

        [Required]
        [StringLength(200)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private ICollection<Employee> employees;

        public ICollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        private ICollection<Comment> comments;

        public ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public Project()
        {
            this.employees = new List<Employee>();
            this.comments = new List<Comment>();
        }
    }
}