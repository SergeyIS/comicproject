using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kogokekat.Models
{
    public class VoteResponseModel
    {
        public String Token { get; set; }
        public int VictimId { get; set; }
        public String Comment { get; set; }
    }
}