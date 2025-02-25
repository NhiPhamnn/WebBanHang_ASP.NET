﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShopBanHang.Models
{
    public class ModelUser
    {
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage ="không thể bỏ trống")]
        public string tenKH { get; set; }
        [Required(ErrorMessage = "không thể bỏ trống")]
        [DisplayName("Địa chỉ")]
        public string diaChi { get; set; }
        
        [Required(ErrorMessage = "không thể bỏ trống")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "không thể bỏ trống")]
        [DisplayName("Số điện thoại")]
        [Phone]
        
        public string sdt { get; set; }
      
        [DisplayName("Tài khoản")]
        public string username { get; set; }
       
        [StringLength(50,MinimumLength =6)]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }
        
       
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="Mật khẩu và xác nhận mật khẩu phải bằng nhau")]
        [DisplayName("Xác nhận mật khẩu")]
        public string confirmPassword { get; set; }
        public double TongMua { get; set; }
    }
}