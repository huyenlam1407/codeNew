using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Models
{
    public class ProductView
    {
        [DisplayName("Mã đơn hàng")]
        public int IDBill { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string CodeProduct { get; set; }
        [DisplayName("Số lượng")]
        public Nullable<int> QuantityProduct { get; set; }
        [DisplayName("Giá tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0}đ", ApplyFormatInEditMode = true)]
        public Nullable<double> PriceProductBuying { get; set; }
        [DisplayName("Giá tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0}đ", ApplyFormatInEditMode = true)]
        public Nullable<double> TotalMoney { get; set; }
        [DisplayName("Mã khách hàng")]
        public string codeCus { get; set; }
        [DisplayName("Ngày mua")]
        public Nullable<System.DateTime> BillDate { get; set; }
    }
}