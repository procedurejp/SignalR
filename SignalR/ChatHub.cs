using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR
{
    [HubName("ChartHub")]
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        [HubMethodName("Send")]
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
        public void Hello(string message)
        {
            Clients.All.HubCallBack(message);
        }
    }
}