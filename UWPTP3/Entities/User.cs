using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTP3.Entities
{
    public class User : EntityBase
    {
        private String firstname;

        public String Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        private String lastname;

        public String Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        private Role role;

        public Role Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }

        public override object Copy()
        {
            User user = new User();
            user.Id = this.Id;
            user.Firstname = this.Firstname;
            user.Lastname = this.Lastname;
            if (this.Role != null)
            {
                user.Role = this.Role.Copy() as Role;
            }

            return user;
        }

        public override void CopyFrom(object obj)
        {
            User user = obj as User;
            this.Id = user.Id;
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            if (user.Role != null)
            {
                this.Role = user.Role;
            }
        }
    }
}
