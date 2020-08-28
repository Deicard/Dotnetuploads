using System;
using System.Linq;
using System.Collections.Generic;
using de_mol.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Library.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> userManager = null;

        public UserService(UserManager<IdentityUser> userManager){
            this.userManager = userManager;
        }

        public async Task<IdentityUser> GetCurrentUser(ClaimsPrincipal principal){
            var user = await userManager.GetUserAsync(principal);

            return user;
        }

        public IEnumerable<IdentityUser> All(){
            return userManager.Users;
        }

    

    }
}