using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Models
{
    public class Post : DbItem
    {
        public int userId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
