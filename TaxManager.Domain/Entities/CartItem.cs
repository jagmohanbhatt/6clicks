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
            TaxDetail taxDetail,
            ShoppingResult shoppingResult)
        {
            BasicFactory = basicFactory;
            ImportFactory = importFactory;
            TaxDetail = taxDetail;
            this.shoppingResult = shoppingResult;
        }
        ShoppingResult shoppingResult = null;
        public List<Item> preparedCart { get; set; }
        public ItemFactory BasicFactory { get; }
        public ItemFactory ImportFactory { get; }
        public TaxDetail TaxDetail { get; }

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
            shoppingResult.TaxDetail = new List<TaxDetail>();

            foreach (var item in preparedCart)
            {
                if (!item.IsExempted())
                {
                    totalBasicTax += basicCalculator.GetTaxAmount(item);
                    TaxDetail.BasicTaxAmount = basicCalculator.GetTaxAmount(item);
                    
                }
                else
                {
                    TaxDetail.BasicTaxAmount = 0.0m;
                }

                if (item.IsImported)
                {
                    totalImportTax += importCalculator.GetTaxAmount(item);
                    TaxDetail.ImportTaxAmount = importCalculator.GetTaxAmount(item);
                }
                shoppingResult.TaxDetail.Add(TaxDetail);

            }

            shoppingResult.TotalImportTax = totalImportTax;
            shoppingResult.TotalSalesTax = totalBasicTax;
            shoppingResult.TotalTax = totalImportTax + totalBasicTax;
            shoppingResult.Total = shoppingResult.TotalWithoutTax + totalImportTax + totalBasicTax;

            return shoppingResult;
        }
    }
}
