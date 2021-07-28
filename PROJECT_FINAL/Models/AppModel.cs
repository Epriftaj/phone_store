using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class AppModel
    {
        public class RoleAssignment
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public bool isChecked { get; set; }//vlere booleane qe kontrollon nese nje rol esht assigned nje user-i
        }

        public class UserRoleViewModel
        {
            public UserRoleViewModel()
            {
                this.UserRoles = new List<RoleAssignment>();
            }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public List<RoleAssignment> UserRoles { get; set; }//ne menyre qe userit ti jepet mundesia te kete disa role
        }
    }
}