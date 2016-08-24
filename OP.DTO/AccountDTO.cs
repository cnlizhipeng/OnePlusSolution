using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations;


namespace OP.DTO
{
    public class LoginDTO
    {
        [Display(Description = "请填写登录用户名",Name = "登录用户", Prompt = "请填写登录用户名")]
        [Required(ErrorMessage = "请填写用户名！")]
        public string UName { get; set; }
        [Display(Description = "请填写用户密码", Name = "用户密码", Prompt = "请填写用户密码")]
        [Required(ErrorMessage ="请填写用户密码！")]
        public string UPWD { get; set; }
        [Display(Description = "请填写验证码", Name = "验证码", Prompt = "请填写验证码")]
        [Required(ErrorMessage = "请填写验证码")]
        [StringLength(4,MinimumLength =4,ErrorMessage ="验证码为四位！")]
        public string ValCode { get; set; }
    }
}
