using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vote_standalone.Models;
using vote_standalone.Models.Sqlite3;
using vote_standalone.Models.FormInputs.User;

namespace vote_standalone.Controllers
{
    public class UserController : Controller
    {
        [Route("create_user")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create_user_submit")]
        [HttpPost]
        public IActionResult CreateSubmit([FromForm] CreateSubmit inputs)
        {
            string uuid = inputs.Uuid;
            string displayName = inputs.DisplayName;

            Sqlite3 sqlite = new Sqlite3();
            try
            {
                sqlite.BeginTransaction();
                vote_standalone.Models.Sqlite3.User.Create(displayName, uuid, sqlite);
                sqlite.Commit();
            }
            catch (Exception e)
            {
                sqlite.Rollback();
            }

            return View();
        }
    }
}
