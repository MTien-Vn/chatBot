using chatBot.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace chatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Server running oke";
        }

        [HttpGet("/weebhook")]
        public string GetResult()
        {
            var token = "manhtien";
            var query = Request.QueryString.Value;
            NameValueCollection qscoll = HttpUtility.ParseQueryString(query);
            var verify_token = qscoll["hub.verify_token"];
            var mode = qscoll["hub.mode"];
            var challenge = qscoll["ub.challenge"];
            if (!string.IsNullOrEmpty(mode) && !string.IsNullOrEmpty(verify_token))
            {
                if(mode=="subscribe" && verify_token == token)
                {
                    return challenge;
                }
            }
            return null;
        }

        [HttpPost("/webhook")]
        public async Task PostRequest([FromBody] PostRequest model)
        {
            if(model.Object == "page")
            {
                for (int i = 0; i < model.Entry.Length; i++)
                {
                    var entry = model.Entry[i];
                    var messaging = entry.messaging;
                    for (int j = 0; j < messaging.Length; j++)
                    {
                        var mess = messaging[j];
                        var senderid = mess.sender.id;
                        if (!string.IsNullOrEmpty(mess.message.text))
                        {
                            var tex = mess.message.text;
                            Console.WriteLine(senderid, tex);
                            await sendMess(senderid, tex);
                        }
                    }
                }
            }
        }

        private async Task sendMess(string senderId, string text)
        {
            var sendRequest = new HttpClientCrudService();
            var obj = new Dictionary<string, object>();
            var sender = new Dictionary<string, string>
            {
                { "id", senderId }
            };
            var mess = new Dictionary<string, string>
            {
                { "text", text }
            };
            obj.Add("recipient", sender);
            obj.Add("message", mess);
            await sendRequest.PostMess(obj);
        }
    }
}
