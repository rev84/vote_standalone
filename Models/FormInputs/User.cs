using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace vote_standalone.Models.FormInputs.User
{
    public class CreateSubmit
    {
        [Required][HiddenInput] public string Uuid { get; set; }
        [Required] public string DisplayName { get; set; }
    }
}