using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace documentationgenerator.Entries
{
    public class MemberParam(string name, string description, string type) 
    {
        public string name { get; set; } = name;
        public string description { get; set; } = description;
        public string type { get; set; } = type; //type.EndsWith('@') ? $"out {type.TrimEnd('@')}" : type;
    }
}
