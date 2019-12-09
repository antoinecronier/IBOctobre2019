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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentaireId
        {
            get { return commentaireId; }
            set { commentaireId = value; }
        }

        private string data;

        [StringLength(200)]
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private Project project;

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

    }
}