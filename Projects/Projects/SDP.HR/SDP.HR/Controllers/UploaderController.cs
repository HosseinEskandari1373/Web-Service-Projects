using FileTypesLib;
using SDP.HR.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace SDP.HR.Controllers
{
    public class UploaderController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.WriteError("Error In " + filterContext.Controller.ToString(), filterContext.Exception);
            base.OnException(filterContext);
        }

        // GET: Uploader
        [HttpPost]
        public JsonResult UploadCVFile(HttpPostedFileBase UploadedCVFile)
        {
            Session["CV"] = null;
            Session["CVFileType"] = null;
            Session["CVFileName"] = null;
            PostResponse response = new PostResponse();
            response.success = false;
            try
            {
                List<string> lstAlloedExtension = new List<string>() { "application/msword", "application/x-zip-compressed", "application/pdf" };
                if (UploadedCVFile != null)
                {
                    if (UploadedCVFile.ContentLength > 1024 * 1024 *AppInfo.MaxCVSize_MB|| UploadedCVFile.ContentLength < 0)
                    {
                        response.message = "سایز فایل انتخابی غیر مجاز است!";
                        return Json(response);
                    }
                    byte[] FileByteArray = new byte[UploadedCVFile.ContentLength];
                    UploadedCVFile.InputStream.Read(FileByteArray, 0, UploadedCVFile.ContentLength);
                    var FileName = UploadedCVFile.FileName;
                    var FileType = UploadedCVFile.ContentType;
                    var FileContent = FileByteArray;
                    FileTypes ft = new FileTypes();
                    string extension = ft.GetMimeType(FileByteArray.Take(256).ToArray(), FileType);
                    if (lstAlloedExtension.Contains(extension))
                    {
                        Session["CV"] = FileByteArray;
                        Session["CVFileType"] = extension;
                        Session["CVFileName"] = UploadedCVFile.FileName;
                    }

                    else
                    {
                        response.message = "لطفا رزومه را در قالب pdf و یا Word آپلود کنید.";
                        return Json(response);
                    }
                    response.success = true;
                    return Json(response);
                }
                else
                {
                    response.message = "فایلی دریافت نشد!";
                    return Json(response);
                }
            }
            catch (Exception exp)
            {
                response.message = exp.Message;
                return Json(response);
            }
        }
        [HttpPost]
        public JsonResult UploadImageFile(HttpPostedFileBase UploadedImageFile)
        {
            Session["Image"] = null;
            Session["ImageFileType"] = null;
            Session["ImageFileName"] = null;
            PostResponse response = new PostResponse();
            response.success = false;
            try
            {
                List<string> lstAlloedExtension = new List<string>() { "image/png", "image/jpg", "image/jpeg" };
                if (UploadedImageFile != null)
                {
                    if (UploadedImageFile.ContentLength > 1024 * 1024 * AppInfo.MaxImageSize_MB || UploadedImageFile.ContentLength < 0)
                    {
                        response.message = "سایز فایل انتخابی غیر مجاز است!";
                        return Json(response);
                    }
                    byte[] FileByteArray = new byte[UploadedImageFile.ContentLength];
                    UploadedImageFile.InputStream.Read(FileByteArray, 0, UploadedImageFile.ContentLength);
                    var FileName = UploadedImageFile.FileName;
                    var FileType = UploadedImageFile.ContentType;
                    var FileContent = FileByteArray;
                    FileTypes ft = new FileTypes();
                    string extension = ft.GetMimeType(FileByteArray.Take(256).ToArray(), FileType);
                    if (lstAlloedExtension.Contains(extension))
                    {
                        Session["Image"] = FileByteArray;
                        Session["ImageFileType"] = extension;
                        Session["ImageFileName"] = UploadedImageFile.FileName;
                    }

                    else
                    {
                        response.message = "لطفا رزومه را در قالب pdf و یا Word آپلود کنید.";
                        return Json(response);
                    }
                    response.success = true;
                    return Json(response);
                }
                else
                {
                    response.message = "فایلی دریافت نشد!";
                    return Json(response);
                }
            }
            catch (Exception exp)
            {
                response.message = exp.Message;
                return Json(response);
            }
        }
    }
}