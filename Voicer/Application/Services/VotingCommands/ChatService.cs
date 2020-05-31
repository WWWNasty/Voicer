using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Chats;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageDto> SendMessageAsync(CreateMessageDto createMessageDto)
        {
            Message message = _mapper.Map<Message>(createMessageDto);

            _unitOfWork.MessageRepository.Create(message);

            await _unitOfWork.SaveChangesAsync();

            var messageDto = _mapper.Map<MessageDto>(message);

            messageDto.User = new UserDto()
            {
                UserName = createMessageDto.UserName
            };
            return messageDto;
        }


        public async Task<List<MessageDto>> GetAllMessagesAsync(GetMessageQueryDto dto)
        {
            return await _unitOfWork.MessageRepository.GetMessages(dto.ChatId, dto.Page, dto.Count);
        }
    }
}