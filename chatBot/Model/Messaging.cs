using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBot.Model
{
    public class Messaging
    {
        public Sender sender { get; set; }
        public Sender recipient { get; set; }
        public Message message { get; set; }
    }
}
