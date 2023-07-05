using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitToCelsiusConversion.Contracts
{
    [ServiceContract(Namespace = "http://fahrenheittocelsiusconversion.azurewebsites.net/")]

    public interface IConversionService
    {
        [OperationContract]
        double FahrenheitToCelsius2(double farenheitDegrees);

        [OperationContract]
        double CelsiusToFahrenheit(double celsiusDegrees);
        [OperationContract]
        decimal ConvertCurrency(int from, int to, decimal value);

        [OperationContract]
        List<string> GetCurrencyNames();
    }
}
