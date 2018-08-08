using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetGitHubAuth.Models;
using System.Security.Claims;

namespace AspNetGitHubAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            if (User.Identity.IsAuthenticated)
            {
                indexModel.GitHubName = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                indexModel.GitHubLogin = User.FindFirst(c => c.Type == "urn:github:login")?.Value;
                indexModel.GitHubUrl = User.FindFirst(c => c.Type == "urn:github:url")?.Value;
                indexModel.GitHubAvatar = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;
            }
            return View(indexModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
