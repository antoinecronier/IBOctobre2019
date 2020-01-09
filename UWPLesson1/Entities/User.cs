using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPLesson1.Entities
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private String firstname;

        public String Firstname
        {
            get { return firstname; }
            set {
                firstname = value;
                OnPropertyChanged("Firstname");
                OnPropertyChanged("FullName");
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
                OnPropertyChanged("FullName");
            }
        }

        public String FullName {
            get { return this.Lastname + this.Firstname; }
        }

        public void CopyFrom(User user)
        {
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
        }
    }
}
