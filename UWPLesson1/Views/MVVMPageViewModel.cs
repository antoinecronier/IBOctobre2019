using System;
using System.Windows.Input;
using UWPLesson1.Entities;

namespace UWPLesson1.Views
{
    public class MVVMPageViewModel
    {
        public User User { get; set; }
        public string ButtonContent { get; set; }


        public MVVMPageViewModel()
        {
            this.User = new User() { Firstname = "John", Lastname = "Connord" };
            this.ButtonContent = "change";
        }
    }
}