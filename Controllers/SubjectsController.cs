using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vote_standalone.Models;
using vote_standalone.Models.Sqlite;
using vote_standalone.Models.FormInputs.Subject;


namespace vote_standalone.Controllers
{
    public class SubjectsController : Controller
    {
        [Route("subjects/input")]
        public IActionResult Input()
        {
            if (!MyUser.Login(Cookie.GetUuid()))
            {
                throw new Exception();
            }

            ViewData["MySubjects"] = Subjects.GetMine(MyUser.GetId());

            return View();
        }
    }
}
