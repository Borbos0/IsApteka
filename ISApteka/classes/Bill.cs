using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISApteka
{
    partial class Bill
    {
        public string FixedImageBill
        {
            get
            {
                if (String.IsNullOrEmpty(BillImage) || String.IsNullOrWhiteSpace(BillImage)) return @"/img/imageBill.jpg";
                else return BillImage;
            }
        }
    }
}
