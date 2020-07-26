using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace vote_standalone.Models.FormInputs.Subject
{
    public class Create
    {
        public const int TITLE_LENGTH_MIN = 1;
        public const int TITLE_LENGTH_MAX = 100;
        public const int ARTIST_LENGTH_MIN = 1;
        public const int ARTIST_LENGTH_MAX = 100;
        public const int URL_LENGTH_MIN = 1;
        public const int URL_LENGTH_MAX = 200;
        public const int COMMENT_LENGTH_MIN = 1;
        public const int COMMENT_LENGTH_MAX = 50;

        [Required] public string Title { get; set; }
        [Required] public string Artist { get; set; }
        [Required] public string Url { get; set; }
        public string Comment { get; set; }

        public void Validate()
        {
            if (Title == null || Title.Length < TITLE_LENGTH_MIN || TITLE_LENGTH_MAX < Title.Length)
            {
                throw new Exception();
            }
            if (Artist == null || Artist.Length < ARTIST_LENGTH_MIN || ARTIST_LENGTH_MAX < Artist.Length)
            {
                throw new Exception();
            }
            if (Url == null || Url.Length < URL_LENGTH_MIN || URL_LENGTH_MAX < Url.Length)
            {
                throw new Exception();
            }
            if (Comment != null && (Comment.Length < COMMENT_LENGTH_MIN || COMMENT_LENGTH_MAX < Comment.Length))
            {
                throw new Exception();
            }
        }
    }
    public class Vote
    {
        public const int POINT_LENGTH_MIN = 1;
        public const int POINT_LENGTH_MAX = 100;
        public const int COMMENT_LENGTH_MIN = 1;
        public const int COMMENT_LENGTH_MAX = 50;

        [Required] public string SubjectId { get; set; }
        [Required] public string Point { get; set; }
        public string Comment { get; set; }

        public void Validate()
        {
            if (SubjectId == null)
            {
                throw new Exception();
            }
            if (Point == null || Point.Length < POINT_LENGTH_MIN || POINT_LENGTH_MAX < Point.Length)
            {
                throw new Exception();
            }
            if (Comment != null && (Comment.Length < COMMENT_LENGTH_MIN || COMMENT_LENGTH_MAX < Comment.Length))
            {
                throw new Exception();
            }
        }
    }
}