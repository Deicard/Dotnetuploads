using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using de_mol.Models;
using Library.Services;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using de_mol.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace de_mol.Controllers
{
    public class VoteController : Controller
    {
        private PlayerService playerService = new PlayerService();
        private VoteService voteService = new VoteService();
        private UserService userService = null;
        private readonly UserManager<IdentityUser> userManager;

        public VoteController(UserManager<IdentityUser> userManager){
            this.userManager = userManager;
            this.userService = new UserService(userManager);
        }
        
        [Authorize]
        [Route("Vote")]
        public IActionResult RedirectVote(){
            return Redirect("/");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Vote(long playerId, int episode)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            voteService.VoteOn(playerId, user.Id, episode);

            return Redirect("/");

        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnVote(long playerId, int episode)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            voteService.UnVoteOn(playerId, user.Id, episode);

            return Redirect("/");
        } 
    }
}