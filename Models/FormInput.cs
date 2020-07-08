using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote_standalone.Models
{
    public static class FormInput
    {
        public static string Get(this Dictionary<string, string> inputs, string key)
        {
            return (inputs.ContainsKey(key) ? inputs[key] : null);
        }
    }
}
