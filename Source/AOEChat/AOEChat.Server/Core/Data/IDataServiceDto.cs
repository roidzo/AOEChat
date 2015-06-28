using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOEChat.Server.Data;
using AOEChat.Server.Models.DTO;

namespace AOEChat.Server.Core.Data
{
    public interface IDataServiceDto
    {  
        //Create Methods
        void CreateMessage(MessageDto message);

        //Read Methods
        IList<MessageDto> GetAllMessages();
        IList<MessageDto> GetMessages();
        IList<MessageDto> GetMessagesForUser(int chatUserId);
        MessageDto GetMessage(int messageId);
    }
}
