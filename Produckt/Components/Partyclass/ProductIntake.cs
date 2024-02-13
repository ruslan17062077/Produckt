using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produckt.Database
{
    public partial class ProductIntake
    {
        public string Summ
        {
            get
            {
                return (Count * Product.Price).ToString();
            }
        }
    }
}
