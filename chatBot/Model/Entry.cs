using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBot.Model
{
    public class Entry
    {
        public string id { get; set; }
        public int time { get; set; }
        public Messaging[] messaging { get; set; }
    }
}
