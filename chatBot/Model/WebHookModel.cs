using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBot.Model
{
    public class WebHookModel
    {
        public string mode { get; set; }
        public string verity_token { get; set; }
        public string challenge { get; set; }
    }
}
