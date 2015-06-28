using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOEChat.Server.Models.DTO
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int ChatUserId { get; set; }
        public string MessageText { get; set; }
        public float GpsXCoord { get; set; }
        public float GpsYCoord { get; set; }
    }
}
