using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFlow
{
  public class ChatModels
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? message { get; set; }

        public ChatModels()  { }

        public ChatModels(ChatMessage chatDB)
        {
            id       = chatDB.Id;
            username = chatDB.Username;
            message  = chatDB.Message;
        }

        public ChatMessage ConvertToChatModel()
        {
            ChatMessage chat = new ChatMessage
            {
                Id = id,
                Username = username,
                Message = message

            };
           return chat;
        }
    }
}
