using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOEChat.Server.Data;
using AOEChat.Server.Models.DTO;

namespace AOEChat.Server.Core.Data
{
    public interface IDataServiceMessage
    {
        //Update Methods
        void CreateMessage(Message message);
        void UpdateMessage(long messageId, string messageText);
        void CreateMessage(int chatUserId, string messageText, float gpsXCoord, float gpsYCoord);
       
        //Read Methods
        IList<Message> GetAllMessages();
        IList<Message> GetMessages();
        IList<Message> GetMessagesForUser(int chatUserId);
        Message GetMessage(int messageId);

        //Delete Methods
        void DeletePastMessages();
        void DeleteAllMessages();

    }
}
