using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vote_standalone.Models;
using vote_standalone.Models.Sqlite3;

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
        public IActionResult CreateSubmit([FromBody] Dictionary<string, string> inputs)
        {
            string uuid = inputs.Get("uuid");
            string displayName = inputs.Get("display_name");

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
