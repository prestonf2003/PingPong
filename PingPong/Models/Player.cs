using System;
using System.Collections.Generic;

namespace PingPong.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Elo { get; set; }
        public int? Rating { get; set; }
        public byte? Wins { get; set; }
        public byte? Loss { get; set; }
    }
}
