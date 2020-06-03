using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain
{
    public class BasicTaxCalculator : TaxCalculator
    {
        private readonly ITaxRateProvider taxRateProvider;
        public BasicTaxCalculator(ITaxRateProvider taxRateProvider)
        {
            this.taxRateProvider = taxRateProvider;
        }
        public override decimal GetTaxRate()
        {
            return taxRateProvider.GetBasicTaxRate() * 100;
        }

        public override decimal GetTaxAmount(Item item)
        {
            return (item.Price * taxRateProvider.GetBasicTaxRate());
        }
    }
}
