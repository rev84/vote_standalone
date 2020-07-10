using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace vote_standalone.Models.FormInputs.Base
{
    public class Uuid
    {
        [Required][HiddenInput] public string MyUuid { get; set; }
    }
}