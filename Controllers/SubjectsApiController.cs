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
            Create inputs = JsonSerializer.Deserialize<Create>(body.ToString());
            try
            {
                MySqlite.BeginTransaction();
                Subjects.Create(inputs.Title, inputs.Artist, inputs.Url, inputs.Comment);
                MySqlite.Commit();
                MySqlite.Close();
            }
            catch (Exception e)
            {
                MySqlite.Rollback();
                MySqlite.Close();
                throw e;
            }
            return
                JsonSerializer.Serialize<object>(new { is_success = true });
        }
    }
}
