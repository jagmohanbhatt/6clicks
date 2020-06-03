
using TaxManager.Domain;

namespace TaxManager.Infrastructure
{
    /// <summary>
    /// We generally make API Calls here - mocked an API call
    /// </summary>
    public class TaxRateProvider : ITaxRateProvider
    {
        public decimal GetBasicTaxRate() => ApiService.ApiManager.GetBasicTax();

        public decimal GetImportTaxRate() => ApiService.ApiManager.GetImportTaxRate();
        
    }
}
