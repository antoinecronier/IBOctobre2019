using AspNetModule11Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetModule11Security.Utils.IdentityUtils
{
    public static class RoleUtils
    {
        public static IdentityRole CreateOrGetRole(string roleName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                IdentityRole result = null;

                if (!roleManager.RoleExists(roleName))
                {
                    result = new IdentityRole();
                    result.Name = roleName;
                    roleManager.Create(result);
                }

                return result ?? roleManager.FindByName(roleName);
            }
        }

        public static void AssignRoleToUser(IdentityRole role, ApplicationUser user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

                userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}