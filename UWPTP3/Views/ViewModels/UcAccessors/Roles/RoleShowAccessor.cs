using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTP3.Entities;

namespace UWPTP3.Views.ViewModels.UcAccessors.Roles
{
    public class RoleShowAccessor
    {
        public Role Role { get; set; }

        public RoleShowAccessor()
        {
            this.Role = new Role();
        }
    }
}
