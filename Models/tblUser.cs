namespace PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblUser
    {
        public int userID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [DisplayName("Họ và Tên")]
        [StringLength(50, MinimumLength = 3)]
        public string userName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DataType("password")]
        [DisplayName("Nhập mật khẩu")]
        public string userPass { get; set; }
        public string userRole { get; set; }
        [NotMapped]
        [DisplayName("Nhập lại mật khẩu")]
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DataType("password")]
        [Compare("userPass")]
        public string rePass { get; set; }

    }
}
