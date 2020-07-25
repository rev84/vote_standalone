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
        [Required] public string Title { get; set; }
        [Required] public string Artist { get; set; }
        [Required] public string Url { get; set; }
        public string Comment { get; set; }

        public void Validate()
        {
            if (Title.Length < 1 || 100 < Title.Length)
            {
                throw new Exception();
            }
            if (Artist.Length < 1 || 100 < Artist.Length)
            {
                throw new Exception();
            }
            if (Url.Length < 1 || 200 < Url.Length)
            {
                throw new Exception();
            }
            if (Comment.Length < 1 || 200 < Comment.Length)
            {
                throw new Exception();
            }
        }
    }
}