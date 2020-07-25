using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using vote_standalone.Models;
using vote_standalone.Models.Sqlite;
using vote_standalone.Models.FormInputs.Subject;

namespace vote_standalone.Controllers
{
    [ApiController]
    public class SubjectsApiController : ControllerBase
    {
        [Route("subjects/create")]
        [HttpPost]
        public string Create([FromBody] JsonElement body)
        {
            if (!MyUser.Login(Cookie.GetUuid()))
            {
                throw new Exception();
            }

            Create inputs = JsonSerializer.Deserialize<Create>(body.ToString());
            try
            {
                inputs.Validate();
                MySqlite.BeginTransaction();
                Subjects.Create(MyUser.GetId(), inputs.Title, inputs.Artist, inputs.Url, inputs.Comment);
                MySqlite.Commit();
                MySqlite.Close();
            }
            catch (Exception e)
            {
                MySqlite.Rollback();
                MySqlite.Close();
                this.Response.StatusCode = 500;
                return Utility.ApiResponse(new { is_success = false });
            }
            return Utility.ApiResponse(new { is_success = true });
        }
    }
}
