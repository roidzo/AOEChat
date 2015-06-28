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
    public class DataServiceMessage : IDataServiceMessage
    {
        private ILogger _logger;
        private IRepository<Message> _messageRepository;

        public DataServiceMessage(ILogger logger, IRepository<Message> messageRepository)
        {
            _logger = logger;
            _messageRepository = messageRepository;
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

        public void CreateMessage(int chatUserId, string messageText, float gpsXCoord, float gpsYCoord)
        {
            using (var db = new AOEChatEntities())
            {
                Message m = new Message();
                m.ChatUserId = chatUserId;
                m.MessageText = messageText;
                m.GpsXCoord = gpsXCoord;
                m.GpsYCoord = gpsYCoord;

                db.Messages.Add(m);

                db.SaveChanges();
            }
        }

        public void CreateMessage(Message message)
        {
            using (var db = new AOEChatEntities())
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
        }


        #endregion


        #region Read Methods

        public IList<Message> GetAllMessages()
        {
            return _messageRepository.SelectAll().ToList();

            //using (var db = new AOEChatEntities())
            //{
            //    List<Message> messages = db.Messages.ToList();
            //    return messages;
            //    //return  AutoMapper.Mapper.Map< System.Data.Entity.DbSet<Locum>, IList<AllLocums.Web.Models.LocumModel>>(locums);
            //    //return null;
            //}
        }

        public IList<Message> GetMessages()
        {
            using (var db = new AOEChatEntities())
            {
                List<Message> messages = db.Messages.ToList();
                return messages;
                //return  AutoMapper.Mapper.Map< System.Data.Entity.DbSet<Locum>, IList<AllLocums.Web.Models.LocumModel>>(locums);
                //return null;
            }
        }

        public IList<Message> GetMessagesForUser(int chatUserId)
        {
            using (var db = new AOEChatEntities())
            {
                List<Message> messages = db.Messages.Where(i => i.ChatUserId == chatUserId).ToList();
                return messages;
            }
        }

        public Message GetMessage(int messageId)
        {
            using (var db = new AOEChatEntities())
            {
                Message message = db.Messages.Single(i => i.MessageId == messageId);
                return message;
            }
        }

        #endregion


        #region Delete Methods

        public void DeletePastMessages()
        {
            DateTime startDateTime = DateTime.Now.AddDays(-2);

            using (var db = new AOEChatEntities())
            {
                List<Message> messages = db.Messages.Where(i => i.TimeSent <= startDateTime).ToList();
                //List<Message> messages = db.Messages.ToList();

                foreach (var t in messages)
                {
                    db.Messages.Remove(t);
                }

                db.SaveChanges();
            }

        }

        public void DeleteAllMessages()
        {
            using (var db = new AOEChatEntities())
            {
                List<Message> messages = db.Messages.ToList();

                foreach (var t in messages)
                {
                    db.Messages.Remove(t);
                }

                db.SaveChanges();
            }

        }

        #endregion


    }
}
