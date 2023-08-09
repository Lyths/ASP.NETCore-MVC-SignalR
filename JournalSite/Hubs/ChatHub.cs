using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JournalSite.Hubs
{
    [Authorize]
    public class ChatHub:Hub
    {
        private readonly DataManager _dataManager;
        public ChatHub(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task Enter(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task Send(string message, string userName, string groupName)
        {
            await Clients.Group(groupName).SendAsync("Receive", message, userName);
            Message mes = new Message
            {
                Sender = userName,
                Text = message,
                GroupName = groupName
            };
            _dataManager.Messages.SaveMessage(mes);
        }
    }
}
