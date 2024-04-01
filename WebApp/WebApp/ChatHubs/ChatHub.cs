using ChatModels;
using Microsoft.AspNetCore.SignalR;
using WebApp.Repos;
namespace WebApp.ChatHubs
{
    public class ChatHub(ChatRepo chatRepo) : Hub  //class ChatHub ke thua tu class Hub(provide by SignalR. handle real-time community)
    {
        public async Task SendMessage(Chat chat)
        {
            await chatRepo.SaveChatAsync(chat);
            await Clients.All.SendAsync("ReceiveMessage", chat);
        }
         
    }
}