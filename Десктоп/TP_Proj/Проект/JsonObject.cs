using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Проект
{
    public class JsonObject
    {
        [JsonProperty("User")]
        public UserInf[] UserInf { get; set; }
    }
}
