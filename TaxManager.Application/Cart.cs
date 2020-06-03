using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;
using System.Linq;
using TaxManager.Infrastructure;
using TaxManager.Domain;

namespace TaxManager.Application
{
    public class Cart
    {
        CartItem cartItem = null;
        public Cart(CartItem _cartItem)
        {
            cartItem = _cartItem;
        }
        public void AddItemToCart(Item[] item)
        {
            cartItem.Add(item);
        }

        public ShoppingResult Buy()
        {
            ShoppingResult result = cartItem.Compute();    //get the basic tax
            return result;
        }
    }
}
