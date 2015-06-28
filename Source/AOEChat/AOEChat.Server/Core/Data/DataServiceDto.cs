using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using AOEChat.Server.Data;
using AOEChat.Server.Models.DTO;
using AutoMapper;

namespace AOEChat.Server.Core.Data
{
    public class DataServiceDto : IDataServiceDto
    {
        private ILogger _logger;
        //private IRepository<Message> _messageRepository;
        private IDataServiceMessage _dataServiceMessage;

        public DataServiceDto(ILogger logger, IDataServiceMessage dataServiceMessage)
        {
            _logger = logger;
            _dataServiceMessage = dataServiceMessage;
            Mapper.CreateMap<Message, MessageDto>();
            //Mapper.CreateMap<MessageDto, Message>();
            Mapper.AssertConfigurationIsValid();
        }


        #region Update Methods

        public void UpdateMessage(long messageId, string messageText)
        {
            using (var db = new AOEChatEntities())
            {
                Message m = db.Messages.Where(i => i.MessageId == messageId).SingleOrDefault();
                m.MessageText = messageText;
                db.SaveChanges();
            }
        }

        public void CreateMessage(MessageDto message)
        {
            _dataServiceMessage.CreateMessage(Mapper.Map<MessageDto, Message>(message));
        }


        #endregion




        #region Read Methods

        public IList<MessageDto> GetAllMessages()
        {
            return Mapper.Map<IList<Message>, IList<MessageDto>>(_dataServiceMessage.GetAllMessages());
        }

        public IList<MessageDto> GetMessages()
        {
            return Mapper.Map<IList<Message>, IList<MessageDto>>(_dataServiceMessage.GetMessages());
        }

        public IList<MessageDto> GetMessagesForUser(int chatUserId)
        {
            return Mapper.Map<IList<Message>, IList<MessageDto>>(_dataServiceMessage.GetMessagesForUser(chatUserId));
        }

        public MessageDto GetMessage(int messageId)
        {
            return Mapper.Map<Message, MessageDto>(_dataServiceMessage.GetMessage(messageId));
        }

        #endregion



    }
}
