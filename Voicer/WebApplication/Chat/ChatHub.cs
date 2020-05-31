using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Extensions;
using BusinessLogicLayer.Abstraction.Services.VotingCommands;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication.Chat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IChatService _chat;

        public ChatHub(IChatService chat)
        {
            _chat = chat;
        }

        public async Task Send(string text, int chatId)
        {
            // if (ModelState.IsValid)
            // {
            var userId = Context.User.GetUserId();
            var userName = Context.User.Identity.Name;
            var sendMessageDto = await _chat.SendMessageAsync(new CreateMessageDto()
            {
                ChatId = chatId,
                UserName = userName,
                UserId = userId,
                Text = text
            });

            await Clients.Group(chatId.ToString()).SendAsync("Send", sendMessageDto);

            // }
            //return View(dto);
        }

        public async Task<List<MessageDto>> GetAllMessages(GetMessageQueryDto dto)
        {
            return await _chat.GetAllMessagesAsync(dto);
        }

        public async Task Connect(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }
}