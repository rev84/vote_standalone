using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace vote_standalone.Models.FormInputs.User
{
    public class CreateSubmit
    {
        [Required][HiddenInput] public string Uuid { get; set; }
        [Required] public string DisplayName { get; set; }

        public void validate()
        {
            if (!Regex.IsMatch(Uuid, "[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}"))
            {
                throw new Exception();
            }
            if (DisplayName.Length < 1 || 10 < DisplayName.Length)
            {
                throw new Exception();
            }
        }
    }
}