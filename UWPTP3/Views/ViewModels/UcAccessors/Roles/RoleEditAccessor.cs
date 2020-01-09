using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTP3.Entities;
using UWPTP3.Views.ViewModels.UcAccessors.Commons;

namespace UWPTP3.Views.ViewModels.UcAccessors.Roles
{
    public class RoleEditAccessor
    {
        public Role Role { get; set; }
        public ButtonAccessor Button { get; set; }

        public RoleEditAccessor()
        {
            this.Role = new Role();
            this.Button = new ButtonAccessor();
        }
    }
}
