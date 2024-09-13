﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblDetailBill
    {
        public int ID { get; set; }
        [DisplayName("Mã đơn hàng")]
        public int IDBill { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string CodeProduct { get; set; }
        [DisplayName("Số lượng")]
        public Nullable<int> QuantityProduct { get; set; }
        [DisplayName("Giá tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0}đ", ApplyFormatInEditMode = true)]
        public Nullable<double> PriceProductBuying { get; set; }
        [DisplayName("Tổng tiền")]
        public Nullable<double> TotalMoney { get; set; }

        public virtual tblBill tblBill { get; set; }
        public virtual tblProduct tblProduct { get; set; }
    }
}
