using System.Collections.Generic;

namespace TaxManager.Domain.Entities
{
    public class ShoppingResult
    {
        public decimal Total { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalImportTax { get; set; }
        public List<Item> ItemsBilled { get; set; }

        //In real world, this normally doesn't exist but we need to show data on console.
        public string FinalMessage { get; set; }
        public decimal TotalTax { get; internal set; }
        public decimal TotalWithoutTax { get; internal set; }
    }
}