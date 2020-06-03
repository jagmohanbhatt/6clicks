using System;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain
{
    public abstract class TaxCalculator
    {
        public abstract decimal GetTaxRate();
        public abstract decimal GetTaxAmount(Item item);
    }
}
