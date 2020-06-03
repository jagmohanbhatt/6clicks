using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManager.Domain.Factory
{
    public class BasicTaxFactory : ItemFactory
    {
        public BasicTaxFactory(ITaxRateProvider provider)
        {
            Provider = provider;
        }

        public ITaxRateProvider Provider { get; }

        public override TaxCalculator CreateFactory()
        {
            return new BasicTaxCalculator(Provider);
        }
    }
}
