using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class Product
    {
        public Product(
            string symbol, 
            int quotes, 
            decimal unitPrice, 
            decimal netValue, 
            DateTime convertedAt
            )
        {
            Symbol = symbol;
            Quotes = quotes;
            UnitPrice = unitPrice;
            NetValue = netValue;
            ConvertedAt = convertedAt;
        }

        public string Symbol{ get; set; }

        public int Quotes { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal NetValue { get; set; }

        public DateTime ConvertedAt { get; set; }
    }
}
