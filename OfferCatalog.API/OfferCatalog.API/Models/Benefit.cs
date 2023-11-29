﻿using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public ItemViewModel Item { get; set; }
        public string Benefits { get; set; }
    }
}
