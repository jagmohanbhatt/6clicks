using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManager.Infrastructure.ApiService
{
    public static class ApiManager
    {
        public static decimal GetBasicTax()
        {
            return 0.1m;
        }

        public static decimal GetImportTaxRate()
        {
            return 0.05m;
        }
    }
}
