using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain.Factory
{
    public abstract class ItemFactory
    {
        public abstract TaxCalculator CreateFactory();
    }
}
