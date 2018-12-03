using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Model {
    public class BidObject {
        [Key]
        public int ItemNumber { get; set; }
        public double ItemPrice { get; set; }
        public string CustomName { get; set; }
        public int CustomPhone { get; set; }
    }
}
