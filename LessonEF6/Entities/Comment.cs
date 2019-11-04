using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEF6.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public User From { get; set; }
        public User To { get; set; }

        public override string ToString()
        {
            return "\n" + Id + " " + Data;
        }
    }
}
