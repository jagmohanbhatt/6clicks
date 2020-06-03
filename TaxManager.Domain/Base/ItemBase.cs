using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain
{
    public abstract class ItemBase
    {
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }

        public abstract bool IsExempted();
    }
}
