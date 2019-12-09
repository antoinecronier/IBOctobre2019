using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Models
{
    [Table("mytable")]
    public class Class1
    {
        private long id;
        private String field1;
        private String field2;
        private String field3;

        [PrimaryKey, AutoIncrement]
        public long Id { get => id; set => id = value; }
        
        public string Field1 { get => field1; set => field1 = value; }
        public string Field2 { get => field2; set => field2 = value; }
        public string Field3 { get => field3; set => field3 = value; }
    }
}
