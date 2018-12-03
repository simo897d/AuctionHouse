using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse.Models {
    public class AuctionItems {
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public int RatingPrice { get; set; }
        public double BidPrice { get; set; }
        public string BidCustomName { get; set; }

        public int BidCustomPhone { get; set; }
        public DateTime BidTimeStamp { get; set; }
    }
}
