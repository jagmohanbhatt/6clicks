using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxManager.Domain.Factory;

namespace TaxManager.Domain.Entities
{
    public class CartItem
    {
        public CartItem(
            BasicTaxFactory basicFactory,
            ImportTaxFactory importFactory,
            ShoppingResult shoppingResult)
        {
            BasicFactory = basicFactory;
            ImportFactory = importFactory;
            this.shoppingResult = shoppingResult;
        }
        ShoppingResult shoppingResult = null;
        public List<Item> preparedCart { get; set; }
        public ItemFactory BasicFactory { get; }
        public ItemFactory ImportFactory { get; }

        public void Add(Item[] itemToAdd)
        {
            preparedCart = itemToAdd.ToList();
        }

        public ShoppingResult Compute()
        {
            TaxCalculator basicCalculator = BasicFactory.CreateFactory();
            TaxCalculator importCalculator = ImportFactory.CreateFactory();

            var totalBasicTax = 0.0m;
            var totalImportTax = 0.0m;
            shoppingResult.TotalWithoutTax = preparedCart.Sum(x => x.Price);
            
            shoppingResult.ItemsBilled = preparedCart;

            foreach (var item in preparedCart)
            {
                if (!item.IsExempted())
                    totalBasicTax += basicCalculator.GetTaxAmount(item);

                if (item.IsImported)
                {
                    totalImportTax += importCalculator.GetTaxAmount(item);
                }
            }

            shoppingResult.TotalImportTax = totalImportTax;
            shoppingResult.TotalSalesTax = totalBasicTax;
            shoppingResult.TotalTax = totalImportTax + totalBasicTax;
            shoppingResult.Total = totalBasicTax;

            return shoppingResult;
        }
    }
}
