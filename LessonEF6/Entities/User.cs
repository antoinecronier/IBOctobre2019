using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEF6.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }
        
        //[Index(IsUnique = true)]
        [MaxLength(300)]
        [MinLength(2)]
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public User()
        {
            this.Comments = new List<Comment>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Id + " " + Firstname + " " + Lastname + " " + DateOfBirth + " ");
            foreach (var item in Comments)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }
    }
}
