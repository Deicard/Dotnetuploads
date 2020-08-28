using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using password_algos_lib.Application;
using masterView.ViewModels.Password;

namespace masterView.Controllers
{
    public class PasswordController : Controller
    {
        public void Index()
        {

            Response.Redirect("/algorithms");
        }

        [Route("algorithms", Name = "alogrithms")]
        public IActionResult Overview(){
            PasswordOverviewViewModel viewModel = new PasswordOverviewViewModel();
            List<string> list = new List<string>();

            list.Add("simple");
            list.Add("ascii");
            list.Add("shift");

            viewModel.Algorithms = list;

            return View(viewModel);
        }

        [Route("password/{algo}", Name = "password")]
        public IActionResult GetPasswordByAlgo(string algo){
            PasswordViewModel viewModel = new PasswordViewModel();

            viewModel.Algo = algo;
            viewModel.Password = "";
            viewModel.Status = "";

            return View(viewModel);
        }

        [HttpPost]
        [Route("password/{algo}/generate", Name = "password.generate")]
        public IActionResult Generate(PasswordViewModel viewModel, string algo){
            PasswordApp app = new PasswordApp();

            viewModel.Algo = algo;
            viewModel.Status = "error";
            //viewModel.Password = "";
            viewModel.Message = "Algorithm [" + algo + "] does't exists!";

            string password = app.run(viewModel.Password, algo);
            if(password != null) {
                viewModel.Status = "success";
                viewModel.Password = password;
                viewModel.Message = "";
            }

            return View(viewModel);
        }
    }
}