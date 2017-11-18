using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalgaryHacks.ChatHub
{
    public class ChatHub : Hub
    {
        public static ConcurrentDictionary<string, string> ConnectionList = new ConcurrentDictionary<string, string>();

        public static ConcurrentDictionary<string, string> UserNamesMap = new ConcurrentDictionary<string, string>();

        public async Task Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            await Clients.All.addNewMessageToPage(name, message);
        }

        [HubMethodName("sendgroup")]
        public async Task SendGroup(string name, string message, String groupId)
        {
            if (message.StartsWith("/call"))
            {
//                await TropoBot.ProcessCallCommand(message);
            }
            // Call the addNewMessageToPage method to update clients.
            await Clients.Group(groupId).addNewMessageToPage(name, message);
        }

        [HubMethodName("groupconnect")]
        public async Task Get_Connect(string username, String groupId)
        {
            string id = Context.ConnectionId;
            await Groups.Add(id, groupId);

            ConnectionList.TryAdd(id, groupId);
            UserNamesMap.TryAdd(id, username);
            await Clients.Group(groupId).addNewMessageToPage("Server", username + " has joined!");
            await DisplayUsersForGroup(groupId);
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            string id = Context.ConnectionId;
            string groupId;
            ConnectionList.TryRemove(id, out groupId);
            string userName;
            UserNamesMap.TryRemove(id, out userName);

            Clients.Group(groupId).addNewMessageToPage("Server", userName + " has left!");
            await DisplayUsersForGroup(groupId);
            await base.OnDisconnected(stopCalled);
        }

        private async Task DisplayUsersForGroup(string groupName)
        {
            IEnumerable<string> ids = ConnectionList.Where(pair => pair.Value == groupName).Select(pair => pair.Key);
            List<string> users = new List<string>();
            foreach (string id in ids)
            {
                users.Add(UserNamesMap[id]);
            }
            await Clients.Group(groupName).displayAllUsers(users);
        }
    }
}