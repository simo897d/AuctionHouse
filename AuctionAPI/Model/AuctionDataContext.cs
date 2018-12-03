using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Model {
    public class AuctionDataContext : DbContext {
        public AuctionDataContext(DbContextOptions<AuctionDataContext> options): base(options) {
            Database.EnsureCreated();
            AuctionItems.Add(new AuctionItems {
                ItemNumber = 1,
                ItemDescription = "Det en bil",
                RatingPrice = 500,
                BidPrice = 0,
                BidCustomName = null,
                BidCustomPhone = 0,
                BidTimeStamp = DateTime.MaxValue

            });

    }
            public DbSet<AuctionItems> AuctionItems { get; set; }



    }
}
