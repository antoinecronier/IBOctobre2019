using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPLesson1.Entities
{
    public class User
    {
        private String firstname;

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private String lastname;

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String FullName { get { return this.Lastname + this.Firstname; }  }
    }
}
