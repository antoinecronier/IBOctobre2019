using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Models
{
    public class Class2AB
    {
        [ForeignKey(typeof(Class2A))]
        public int IdClass2A { get; set; }
        
        [ForeignKey(typeof(Class2B))]
        public int IdClass2B { get; set; }
    }
}
