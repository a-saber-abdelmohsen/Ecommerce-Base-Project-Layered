using BL.Bases;
using BL.ViewModels;
using DAL.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : BaseAppService
    {
        public ApplicationUser Find (string username, string password)
        {
            return TheUnitOfWork.Account.Find(username, password);
        }

        public IdentityResult Register (RegisterViewModel userModel)
        {
            ApplicationUser user = Mapper.Map<ApplicationUser>(userModel);
            return TheUnitOfWork.Account.Register(user);
        }

        public IdentityResult AssignToRole(string userId, string role)
        {
            return TheUnitOfWork.Account.AssignToRole(userId, role);
        }


        public Task<ApplicationUser> FindByEmailAndPassword (string email, string password)
        {
            return TheUnitOfWork.Account.FindByEmailAndPassword(email, password);
        }

    }
}
