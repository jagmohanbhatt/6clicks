using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain
{
    public class ImportTaxCalculator : TaxCalculator
    {
        private readonly ITaxRateProvider taxRateProvider;

        public ImportTaxCalculator(ITaxRateProvider taxRateProvider)
        {
            this.taxRateProvider = taxRateProvider;
        }

        public override decimal GetTaxRate()
        {
            return taxRateProvider.GetImportTaxRate() * 100;
        }

        public override decimal GetTaxAmount(Item item)
        {
            return (item.Price * taxRateProvider.GetImportTaxRate());
        }
    }
}
