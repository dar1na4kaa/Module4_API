using System;
using Newtonsoft;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_4
{
    public  class JsonResponse
    {
        [JsonProperty("value")]
        public  string Value { get; set; }   
    }
}
