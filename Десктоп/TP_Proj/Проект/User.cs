using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Проект
{
    struct User
    {
        [JsonProperty("login")]
        public string login { get; set; }
        [JsonProperty("mail")]
        public string mail { get; set; }
        [JsonProperty("pass")]
        public string pass { get; set; }
    }
}
