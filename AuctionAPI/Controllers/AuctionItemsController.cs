using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuctionAPI.Model;

namespace AuctionAPI.Controllers
{
    [Route("api/auctionitems")]
    [ApiController]
    public class AuctionItemsController : ControllerBase {
        private readonly AuctionDataContext _context;

        public AuctionItemsController(AuctionDataContext context) {
            _context = context;
        }

        // GET: api/AuctionItems
        [HttpGet]
        public IEnumerable<AuctionItems> GetAuctionItems() {
            return _context.AuctionItems;
        }

        // GET: api/AuctionItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuctionItems([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var auctionItems = await _context.AuctionItems.FindAsync(id);

            if (auctionItems == null) {
                return NotFound();
            }

            return Ok(auctionItems);
        }

        // PUT: api/AuctionItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuctionItems([FromRoute] int id, [FromBody] AuctionItems auctionItems) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != auctionItems.ItemNumber) {
                return BadRequest();
            }

            _context.Entry(auctionItems).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!AuctionItemsExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AuctionItems
        [HttpPost]
        public async Task<IActionResult> PostAuctionItems([FromBody] AuctionItems auctionItems) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.AuctionItems.Add(auctionItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuctionItems", new { id = auctionItems.ItemNumber }, auctionItems);
        }

        // DELETE: api/AuctionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuctionItems([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var auctionItems = await _context.AuctionItems.FindAsync(id);
            if (auctionItems == null) {
                return NotFound();
            }

            _context.AuctionItems.Remove(auctionItems);
            await _context.SaveChangesAsync();

            return Ok(auctionItems);
        }

        [HttpPost("{id}/bid")]
        public async Task<IActionResult> ProvideBid([FromRoute]int id, [FromBody] BidObject bidObject) {
            if (!ModelState.IsValid) {
                return NotFound();
            }
            

            var auctionItem = _context.AuctionItems.FirstOrDefault(x => x.ItemNumber == id);

            if(auctionItem == null) {
                return NotFound("Varen findes ikke");
            }

            if(bidObject.ItemPrice > auctionItem.BidPrice) {
                auctionItem.BidPrice = bidObject.ItemPrice;
                auctionItem.BidCustomName = bidObject.CustomName;
                auctionItem.BidCustomPhone = bidObject.CustomPhone;
                auctionItem.BidTimeStamp = DateTime.Now;
                //auctionItem.ListofBidObjects.Add(bidObject);
                _context.SaveChanges();
            return Ok(bidObject);
            }
            await _context.SaveChangesAsync();
            return NotFound("Buddet er for lavt");
        }

        private bool AuctionItemsExists(int id)
        {
            return _context.AuctionItems.Any(e => e.ItemNumber == id);
        }
    }
}