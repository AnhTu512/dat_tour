using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourDL.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập tài khoản !")]
        public String UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu !")]
        public String PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}