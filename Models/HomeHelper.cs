using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vote_standalone.Models.Sqlite;

namespace vote_standalone.Models
{
    public class HomeHelper
    {
        public static object GetSubjects(int? UserId)
        {
            return new {
                now = Infos.GetNowSubjectId(),
                subjects = Subjects.GetAll(),
            };
        }
    }
}
