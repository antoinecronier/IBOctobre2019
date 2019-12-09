using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Models
{
    public class Class2B
    {
        private int id;
        private String data;
        private Class2A subClassA;
        private List<Class2A> listClass2A;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }

        public string Data { get => data; set => data = value; }

        [ManyToOne]
        public Class2A SubClassA { get => subClassA; set => subClassA = value; }

        [ManyToMany(typeof(Class2AB))]
        public List<Class2A> ListClass2A { get => listClass2A; set => listClass2A = value; }
    }
}
