using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBot.Model
{
    public class PostRequest
    {
        public string Object { get; set; }
        public Entry[] Entry { get; set; }
    }
}
