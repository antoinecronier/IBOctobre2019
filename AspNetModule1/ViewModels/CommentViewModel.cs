using AspNetModule1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetModule1.ViewModels
{
    public class CommentViewModel : ViewModelBase<Comment>
    {
        public CommentViewModel()
        {
            this.ShowActionLinks = false;
        }
    }
}