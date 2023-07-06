using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class LoggingModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("dateoflog")]
        public DateTime DateOfLog { get; set; }
        [JsonProperty("ip")]
        public string? IP { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set; }
        [JsonProperty("number1")]
        public float? Number1 { get; set; }
        [JsonProperty("number2")]
        public float? Number2 { get; set; }
        [JsonProperty("result")]
        public float? Result { get; set; }
        [JsonProperty("action")]
        public TaskType Action { get; set; }
    }
}
