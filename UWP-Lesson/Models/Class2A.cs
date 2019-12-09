using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Models
{
    public class Class2A
    {
        private int id;
        private DateTime myDate;
        private String data;
        private Class2A subClassA;
        private List<Class2B> listClass2B;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }

        public DateTime MyDate { get => myDate; set => myDate = value; }
        public string Data { get => data; set => data = value; }

        [ManyToOne]
        public Class2A SubClassA { get => subClassA; set => subClassA = value; }

        [ForeignKey(typeof(Class2A))]
        public int SubClassAId { get; set; }

        [ManyToMany(typeof(Class2AB))]
        public List<Class2B> ListClass2B { get => listClass2B; set => listClass2B = value; }
    }
}
