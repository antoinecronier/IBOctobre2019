using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetModule1.Models
{
    public class Comment
    {
        private int commentaireId;
        private string data;
        private Project project;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentaireId
        {
            get { return commentaireId; }
            set { commentaireId = value; }
        }

        [StringLength(200)]
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }
    }
}