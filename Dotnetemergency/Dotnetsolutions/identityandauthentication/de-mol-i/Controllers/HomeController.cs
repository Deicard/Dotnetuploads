using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using de_mol.Models;
using Library.Services;
using ViewModels;
using Microsoft.AspNetCore.Identity;

namespace de_mol.Controllers
{
    public class HomeController : Controller
    {

        private PlayerService playerService = new PlayerService();
        private VoteService voteService = new VoteService();
        private UserService userService = null;

        private readonly UserManager<IdentityUser> userManager;

        public HomeController(UserManager<IdentityUser> userManager){
            this.userManager = userManager;
            this.userService = new UserService(userManager);
        }


        public async Task<IActionResult> Index()
        {
            var user = await userService.GetCurrentUser(HttpContext.User);
            var userId = user == null ? "0" : user.Id;
            int episode = 1;
            
            long yourVote = user == null ? 0 : voteService.YourVote(userId, episode);
            
            HomeIndexViewModel viewModel = new  HomeIndexViewModel();
            viewModel.Players = playerService.All();
            viewModel.Votes = voteService.TotalPerPlayer(episode);
            viewModel.CanVote = yourVote == 0 ? true : false;
            viewModel.YourVote = yourVote;
            viewModel.Episode = episode;
            viewModel.TotalVotes = voteService.TotalPerEpisode(episode);

            return View(viewModel);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

