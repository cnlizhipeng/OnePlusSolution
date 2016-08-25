using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OP.IBLL;
using OP.BLL;
using System.Web.Security;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace OP.MvcView.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            ViewBag.Title = "系统名称";//可以取配置文件中的内容
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(FormCollection hct)
        //{
        //    ViewBag.ErrorMessage = "";
        //    string uname = hct["username"];
        //    string upwd = hct["userpwd"];
        //    string yanzhengm = Session["ValGrap"] == null ? "" : Session["ValGrap"].ToString();
        //    string clientYanzhengm = hct["GL_StandardCode"];
        //    ISystemUserBLL iub = new SystemUserBLL();
        //    var finduser = iub.Login(uname, upwd, "");
        //    if (finduser != null && yanzhengm.Equals(clientYanzhengm))
        //    {
        //        if (Session["User"] == null)
        //            Session.Add("User", finduser);
        //        else
        //            Session["User"] = finduser;
        //        FormsAuthentication.SetAuthCookie(finduser.UserName, false);
        //        return RedirectToAction("index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "用户名密码错误，或者没有填写验证码！";
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Index(OP.DTO.LoginDTO entity)
        {
            if (ModelState.IsValid)
            {
                string uname = entity.UName;
                string upwd = entity.UPWD;
                string yanzhengm = Session["ValGrap"] == null ? "" : Session["ValGrap"].ToString();
                string clientYanzhengm = entity.UPWD;
                ISystemUserBLL iub = new SystemUserBLL();
                var finduser = iub.Login(uname, upwd, "");
                if (finduser != null && yanzhengm.Equals(clientYanzhengm))
                {
                    if (Session["User"] == null)
                        Session.Add("User", finduser);
                    else
                        Session["User"] = finduser;
                    FormsAuthentication.SetAuthCookie(finduser.UserName, false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
                return View();
        }

        public JsonResult Login(string uname, string upwd, string valcode)
        {
            string yanzhengm = Session["ValGrap"] == null ? "" : Session["ValGrap"].ToString();
            if (yanzhengm.Equals(valcode))
            {
                ISystemUserBLL iub = new SystemUserBLL();
                var finduser = iub.Login(uname, upwd, "");
                if (finduser != null)
                {
                    if (Session["User"] == null)
                        Session.Add("User", finduser);
                    else
                        Session["User"] = finduser;
                    FormsAuthentication.SetAuthCookie(finduser.UserName, false);
                    return Json("sucess", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("用户名密码错误！", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("验证码错误！", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetImg()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = ValidateCode.CreateValidateGraphic(out code, 4, width, height, fontsize);
            if (Session["ValGrap"] == null)
                Session.Add("ValGrap", code);
            else
                Session["ValGrap"] = code;
            return File(bytes, @"image/jpeg");
        }

        public ActionResult MyTasks()
        {
            return View();
        }

        public ActionResult MyMessages()
        {
            return View();
        }

        public ActionResult MyNotifications()
        {
            return View();
        }

        public ActionResult MyNormalSet()
        {
            return View();
        }

        public ActionResult MyModules()
        {
            IAccountBLL ab = new AccountBLL();
            var q = ab.GetModules();
            return View(q);
        }

        public ActionResult ModuleTree(int parentId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            IAccountBLL ab = new AccountBLL();
            var Nodes = ab.GetModules().Where(x => x.PID == parentId).OrderBy(x=>x.ViewOrder);
            foreach (var pNode in Nodes)
            {
                sb.Append("<ul class=\"easyui-tree\">");
                var sNodes = ab.GetModules().Where(x => x.PID == pNode.ID).OrderBy(x => x.ViewOrder);
                if (sNodes.Count() > 0)
                {
                    sb.Append("<li data-options=\"state: 'closed'\">");
                    sb.Append(string.Format("<span>{0}</span>", pNode.ModuleName));
                    sb.Append("<ul>");
                    foreach (var sNode in sNodes)
                    {
                        sb.Append("<li>");
                        sb.Append(string.Format("<span>{0}</span>",sNode.ModuleName));
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append(string.Format("<li>{0}</li>", pNode.ModuleName));
                }
                sb.Append("</ul>");
            }

            return Content(sb.ToString());
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
            ViewBag.Title = "系统用户管理";
            return View();
        }

        public JsonResult GetUsers()
        {
            IAccountBLL ab = new AccountBLL();
            var q = ab.GetAll();
            return Json(q, JsonRequestBehavior.AllowGet);
        }
    }

    //2.1随机码和图片流生成

    public class ValidateCode
    {
        /// <summary>
        /// 產生圖形驗證碼。
        /// </summary>
        /// <param name="Code">傳出驗證碼。</param>
        /// <param name="CodeLength">驗證碼字元數。</param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="FontSize"></param>
        /// <returns></returns>
        public static byte[] CreateValidateGraphic(out String Code, int CodeLength, int Width, int Height, int FontSize)
        {
            String sCode = String.Empty;
            //顏色列表，用於驗證碼、噪線、噪點
            Color[] oColors ={
             System.Drawing.Color.Black,
             System.Drawing.Color.Red,
             System.Drawing.Color.Blue,
             System.Drawing.Color.Green,
             System.Drawing.Color.Orange,
             System.Drawing.Color.Brown,
             System.Drawing.Color.Brown,
             System.Drawing.Color.DarkBlue
            };
            //字體列表，用於驗證碼
            string[] oFontNames = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            //驗證碼的字元集，去掉了一些容易混淆的字元
            char[] oCharacter = {
       '2','3','4','5','6','8','9',
       'A','B','C','D','E','F','G','H','J','K', 'L','M','N','P','R','S','T','W','X','Y'
      };
            Random oRnd = new Random();
            Bitmap oBmp = null;
            Graphics oGraphics = null;
            int N1 = 0;
            System.Drawing.Point oPoint1 = default(System.Drawing.Point);
            System.Drawing.Point oPoint2 = default(System.Drawing.Point);
            string sFontName = null;
            Font oFont = null;
            Color oColor = default(Color);

            //生成驗證碼字串
            for (N1 = 0; N1 <= CodeLength - 1; N1++)
            {
                sCode += oCharacter[oRnd.Next(oCharacter.Length)];
            }

            oBmp = new Bitmap(Width, Height);
            oGraphics = Graphics.FromImage(oBmp);
            oGraphics.Clear(System.Drawing.Color.White);
            try
            {
                for (N1 = 0; N1 <= 4; N1++)
                {
                    //畫噪線
                    oPoint1.X = oRnd.Next(Width);
                    oPoint1.Y = oRnd.Next(Height);
                    oPoint2.X = oRnd.Next(Width);
                    oPoint2.Y = oRnd.Next(Height);
                    oColor = oColors[oRnd.Next(oColors.Length)];
                    oGraphics.DrawLine(new Pen(oColor), oPoint1, oPoint2);
                }

                float spaceWith = 0, dotX = 0, dotY = 0;
                if (CodeLength != 0)
                {
                    spaceWith = (Width - FontSize * CodeLength - 10) / CodeLength;
                }

                for (N1 = 0; N1 <= sCode.Length - 1; N1++)
                {
                    //畫驗證碼字串
                    sFontName = oFontNames[oRnd.Next(oFontNames.Length)];
                    oFont = new Font(sFontName, FontSize, FontStyle.Italic);
                    oColor = oColors[oRnd.Next(oColors.Length)];

                    dotY = (Height - oFont.Height) / 2 + 2;//中心下移2像素
                    dotX = Convert.ToSingle(N1) * FontSize + (N1 + 1) * spaceWith;

                    oGraphics.DrawString(sCode[N1].ToString(), oFont, new SolidBrush(oColor), dotX, dotY);
                }

                for (int i = 0; i <= 30; i++)
                {
                    //畫噪點
                    int x = oRnd.Next(oBmp.Width);
                    int y = oRnd.Next(oBmp.Height);
                    Color clr = oColors[oRnd.Next(oColors.Length)];
                    oBmp.SetPixel(x, y, clr);
                }

                Code = sCode;
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                oBmp.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                oGraphics.Dispose();
            }
        }
    }
}