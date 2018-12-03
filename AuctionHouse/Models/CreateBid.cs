using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse.Models {
    public class CreateBid {
        public int ItemNumber { get; set; }
        public double ItemPrice { get; set; }
        public string CustomName { get; set; }
        public int CustomPhone { get; set; }
    }
}
