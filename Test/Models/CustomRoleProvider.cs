using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using StorageCompany.Models;

namespace StorageCompany.Models
{
    public class CustomRoleProvider : RoleProvider
    {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (StorageEntityDataModel db = new StorageEntityDataModel())
            {
                var user = db.User.FirstOrDefault(x => x.username == username);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return new String[] { user.Role.name };
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (StorageEntityDataModel db = new StorageEntityDataModel())
            {
                User user = db.User.FirstOrDefault(u => u.username.Equals(username));
                if (roleName == user.Role.name)
                    return true;
                else
                    return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            using (StorageEntityDataModel db = new StorageEntityDataModel())
            {
                Role role = db.Role.FirstOrDefault(r => r.name.Equals(roleName));
                if (role != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
