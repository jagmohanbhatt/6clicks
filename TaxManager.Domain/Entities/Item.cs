using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManager.Domain.Entities
{
    public class Item : ItemBase
    {
        public override bool IsExempted()
        {
            //In ideal world this should be fetched from an API
            return (ItemType.Book | ItemType.Food | ItemType.Medical).HasFlag(this.Type);
        }

        public Item(ItemType type, string name, int qty, decimal price, bool imported = false)
        {
            Type = type;
            Name = name;
            Qty = qty;
            Price = price;
            IsImported = imported;
        }
    }
}
