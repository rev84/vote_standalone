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
            inputs.Validate();
            Subjects.Create(MyUser.GetId(), inputs.Title, inputs.Artist, inputs.Url, inputs.Comment);
            return Utility.ApiResponse(new { is_success = true });
        }

        [Route("subjects/vote")]
        [HttpPost]
        public string Vote([FromBody] JsonElement body)
        {
            if (!MyUser.Login(Cookie.GetUuid()))
            {
                throw new Exception();
            }

            Vote inputs = JsonSerializer.Deserialize<Vote>(body.ToString());
            inputs.Validate();
            SubjectVotes.Replace(
                Convert.ToInt32(inputs.SubjectId),
                Convert.ToInt32(MyUser.GetId()),
                Convert.ToInt32(inputs.Point),
                inputs.Comment
            );

            return Utility.ApiResponse(new { is_success = true });
        }
    }
}
