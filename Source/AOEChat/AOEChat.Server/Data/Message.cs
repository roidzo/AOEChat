//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AOEChat.Server.Data
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class Message
    {
        public int MessageId { get; set; }
        public int ChatUserId { get; set; }
        public string MessageText { get; set; }
        public float GpsXCoord { get; set; }
        public float GpsYCoord { get; set; }
        public System.DateTime TimeSent { get; set; }
    
        public virtual ChatUser ChatUser { get; set; }
    }
}
