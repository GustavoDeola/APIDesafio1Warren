using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    
    public class Portfolio
    {
        public Portfolio(
            decimal totalBalance, 
            ICollection<Product> products
            )
        {
            TotalBalance = totalBalance;
            Products = products;
        }

        public decimal TotalBalance { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
