using System;
using System.Collections.Generic;

namespace CallFlow
{
    public partial class ChatMessage
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Message { get; set; }
    }
}
