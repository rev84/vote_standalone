using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using vote_standalone.Models;
using vote_standalone.Models.Sqlite;

namespace vote_standalone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [Route("")]
        public IActionResult Index()
        {
            if (!MyUser.Login(Cookie.GetUuid()))
            {
                MyUser.CreateUser();
            }

            ViewData["Subjects"] = Subjects.GetAll();
            ViewData["Now"] = Infos.GetNowSubjectId();
            return View();
        }

        /*
        [Route("get_subjects")]
        public IActionResult GetSubjects()
        {
            if (!MyUser.Login(Cookie.GetUuid()))
            {
                throw new Exception();
            }

            var results = HomeHelper.GetSubjects(MyUser.GetId());
            MySqlite.Close();
            return Content(
                JsonConvert.SerializeObject(results),
                "application/json"
            );
        }
        */


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
