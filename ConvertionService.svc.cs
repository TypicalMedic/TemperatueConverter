using FahrenheitToCelsiusConversion.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitToCelsiusConversion.Services
{
    public class ConversionService : IConversionService
    {
        readonly ServiceReference1.DailyInfoSoapClient cb = new ServiceReference1.DailyInfoSoapClient();
        public double FahrenheitToCelsius2(double farenheitDegrees)
        {
            return 5.0 / 9 * (farenheitDegrees - 32);
        }

        public double CelsiusToFahrenheit(double celsiusDegrees)
        {
            return 9.0 / 5 * celsiusDegrees + 32;
        }

        public decimal ConvertCurrency(int from, int to, decimal value)
        {
            DataRowCollection rows = cb.GetCursOnDate(DateTime.Now).Tables[0].Rows;
            rows.Add(new object[] { "Российский рубль", 1, 1, 1, "RUB" });
            DataRow fromR = rows[from];
            decimal fromC = (decimal)fromR[2];
            decimal fromN = (decimal)fromR[1];
            DataRow toR = rows[to];
            decimal toC = (decimal)toR[2];
            decimal toN = (decimal)toR[1];
            return value * fromC * toN / (fromN * toC);
        }

        public List<string> GetCurrencyNames()
        {
            List<string> res = new List<string>();
            foreach (var x in cb.GetCursOnDate(DateTime.Now).Tables[0].Rows)
            {
                DataRow row = (DataRow)x;
                res.Add(row.ItemArray[0].ToString());
            }
            res.Add("Российский рубль");
            return res;
        }
    }
}
