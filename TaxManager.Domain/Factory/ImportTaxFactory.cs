using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManager.Domain.Factory
{
    public class ImportTaxFactory : ItemFactory
    {
        public ImportTaxFactory(ITaxRateProvider provider)
        {
            Provider = provider;
        }

        public ITaxRateProvider Provider { get; }

        public override TaxCalculator CreateFactory()
        {
            return new ImportTaxCalculator(Provider);
        }
    }
}
