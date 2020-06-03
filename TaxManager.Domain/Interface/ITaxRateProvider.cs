using System;
using System.Collections.Generic;
using System.Text;
using TaxManager.Domain.Entities;

namespace TaxManager.Domain
{
    public interface ITaxRateProvider
    {
        decimal GetBasicTaxRate();
        decimal GetImportTaxRate();
    }
}
