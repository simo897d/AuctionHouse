using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Model {
    public class AuctionItems {
       // public List<BidObject> ListofBidObjects { get; set; }
        [Key]
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public int RatingPrice { get; set; }
        public double BidPrice { get; set; }
        public string BidCustomName { get; set; }

        public int BidCustomPhone { get; set; }
        public DateTime BidTimeStamp { get; set; }
    }
}
