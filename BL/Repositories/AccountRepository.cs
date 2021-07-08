using DAL.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class AccountRepository//: BaseRepository<ApplicationUserIdentity>
    {
        readonly ApplicationUserManager manager;

        public AccountRepository(DbContext db)
        {
            manager = new ApplicationUserManager(db);
        }


        public ApplicationUser Find(string username, string password)
        {
            return manager.Find(username, password);
            
        }

        public IdentityResult Register (ApplicationUser user)
        {
            return manager.Create(user, user.PasswordHash);
        }

        public IdentityResult AssignToRole (string userId, string roleName)
        {
            return manager.AddToRole(userId, roleName);
        }

        public async Task<ApplicationUser> FindByEmailAndPassword(string Email, string Password)
        {
            var userForEmail = await manager.FindByEmailAsync(Email);
            if (userForEmail != null)
            {
                var username = userForEmail.UserName;
                return await manager.FindAsync(username, Password);
            }
            return null;
        }
    }
}
