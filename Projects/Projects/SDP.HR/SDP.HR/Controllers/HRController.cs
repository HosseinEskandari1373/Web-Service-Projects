using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SDP.HR.Classes;
using SDP.HR.Models;

namespace SDP.HR.Controllers
{
    public class HRController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.WriteError("Error In " + filterContext.Controller.ToString(), filterContext.Exception);
            base.OnException(filterContext);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JavaScriptProblem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string str)
        {
            PostResponse response = new PostResponse();
            response.success = true;
            List<ControlError> lstError = new List<ControlError>();
            Person p = Person.FromForm(Request.Form);

            try
            {
                PersianDate bd = new PersianDate(p.BirthDate);
                if (bd.Year>DateTime.Now.Year-18 || bd.Year<1300)
                    lstError.Add(new ControlError { ControlId = "txtBirthDate", ErrorText = "تاریخ تولد معتبر نمی‌باشد!" });
            }
            catch {
                    lstError.Add(new ControlError { ControlId = "txtBirthDate", ErrorText = "تاریخ تولد معتبر نمی‌باشد!" });
            }
            try
            {
                if (p.CertificatePlace.Length<=0)
                    lstError.Add(new ControlError { ControlId = "txtCertificatePlace", ErrorText = "محل صدور شناسنامه معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                if (p.BirthPlace.Length <= 0)
                    lstError.Add(new ControlError { ControlId = "cmbxBirthCity", ErrorText = "محل تولد معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                if (p.City.Length <= 0)
                    lstError.Add(new ControlError { ControlId = "cmbxCity", ErrorText = "شهر معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                p.Attachment = (byte[])(Session["CV"]);
                p.FileType = Session["CVFileType"].ToString();
                p.FileName= Session["CVFileName"].ToString();
            }
            catch { }
            try
            {
                p.Image = (byte[])(Session["Image"]);
                p.ImageFileType = Session["ImageFileType"].ToString();
                p.ImageFileName = Session["ImageFileName"].ToString();
            }
            catch { }
            bool OKCaptcha = false;
            #region Check Captcha
            try
            {
                int captchaCode = int.Parse(Request.Form["CaptchaCode"]);
                if ((int)Session["CaptchaCode"] == captchaCode)
                {
                    OKCaptcha = true;
                }
            }
            catch
            {

            }
            if (!OKCaptcha)
                lstError.Add(new ControlError { ControlId = "txtCaptchCode", ErrorText = "کد امنیتی وارد شده صحیح نمی باشد!" });
            #endregion

            #region Insert Person
            if (lstError.Count == 0)
            {
                try
                {
                    p.Insert();
                }
                catch(Exception exp)
                {
                    Logger.WriteError("Error In Inserting Person",exp);
                    //System.IO.File.WriteAllText($@"C:\WebLog\{DateTime.Now.Date}.txt", 
                    //    $"+++{DateTime.Now}+++\r\n Message:{exp.Message}---InnerExecption:{exp.InnerException}-----Source:{exp.Source}---Data:{exp.Data}");
                    string msg = exp.Message;
                    response.success = false;
                    response.message = "خطا در درج اطلاعات، لطفا لحظاتی دیگر مجددا تلاش کنید.";
                }
            } 
            #endregion

            response.errors = lstError.ToArray();
            if (lstError.Count > 0)
            {
                response.success = false;
                if (response.message.Length == 0)
                    response.message = "لطفا خطاهای مشخص شده را بر طرف کنید.";
            }
            return Json(response);
        }
        public ActionResult ShowCaptchaImage()
        {
            bool noisy = true;
            var rand = new Random((int)DateTime.Now.Ticks);
            int a = rand.Next(1000, 9999);
            //int b = rand.Next(0, 9);
            var captcha = string.Format("{0}", a);
            Session["CaptchaCode"] = a;
            FileContentResult img = null;
            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(50, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 5; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }
            return img;
        }
        [HttpGet]
        public JsonResult GetCities(short id)
        {
            try
            {
                return Json(City.SelectByProvinceId(id), JsonRequestBehavior.AllowGet);
            }
            catch 
            {
                return null;
            }
        }
    }
}