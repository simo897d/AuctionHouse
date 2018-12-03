﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuctionHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace AuctionHouse.Services {
    public class AuctionApiProxy {
        const string baseUrl = "https://localhost:44369/api";
        
        public async Task<IEnumerable<AuctionItems>> GetItemsAsync() {
            var url = $"{baseUrl}/auctionitems";

            var client = new HttpClient();

            string Json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<AuctionItems>>(Json);
        }
    }
}
