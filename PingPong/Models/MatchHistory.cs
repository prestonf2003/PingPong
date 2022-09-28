using System;
using System.Collections.Generic;

namespace PingPong.Models
{
    public partial class MatchHistory
    {
        public int Id { get; set; }
        public string? Player1name { get; set; }
        public string? Player2name { get; set; }
        public string? Score { get; set; }
    }
}
