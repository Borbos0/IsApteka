using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka
{
    partial class Stock
    {
        public string FixedImageStock
        {
            get
            {
                if (String.IsNullOrEmpty(DrugImage) || String.IsNullOrWhiteSpace(DrugImage)) return @"/logo/logo.png";
                else return DrugImage;
            }
        }
    }
}
