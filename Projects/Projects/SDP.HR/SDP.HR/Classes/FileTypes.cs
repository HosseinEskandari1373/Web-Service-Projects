using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace FileTypesLib
{
    public class FileTypes
    {

        #region GetMimeType
        private readonly byte[] BMP = { 66, 77 };
        private readonly byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
        private readonly byte[] EXE_DLL = { 77, 90 };
        private readonly byte[] GIF = { 71, 73, 70, 56 };
        private readonly byte[] ICO = { 0, 0, 1, 0 };
        private readonly byte[] JPG = { 255, 216, 255 };
        private readonly byte[] MP3 = { 255, 251, 48 };
        private readonly byte[] OGG = { 79, 103, 103, 83, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
        private readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
        private readonly byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
        private readonly byte[] RAR = { 82, 97, 114, 33, 26, 7, 0 };
        private readonly byte[] SWF = { 70, 87, 83 };
        private readonly byte[] TIFF = { 73, 73, 42, 0 };
        private readonly byte[] TORRENT = { 100, 56, 58, 97, 110, 110, 111, 117, 110, 99, 101 };
        private readonly byte[] TTF = { 0, 1, 0, 0, 0 };
        private readonly byte[] WAV_AVI = { 82, 73, 70, 70 };
        private readonly byte[] WMV_WMA = { 48, 38, 178, 117, 142, 102, 207, 17, 166, 217, 0, 170, 0, 98, 206, 108 };
        private readonly byte[] ZIP_DOCX = { 80, 75, 3, 4 };

        /// <summary>
        /// References a set of readonly byte arrays containing the "magic" identifying
        /// bytes contained in the file header of various file types
        /// </summary>
        /// <param name="fileName">The file to examine</param>
        /// <returns>The Mime type as a string</returns>
        /// <remarks>
        /// Adapted from ROFLwTIME at http://stackoverflow.com/questions/58510/using-net-how-can-you-find-the-mime-type-of-a-file-based-on-the-file-signature
        /// </remarks>
        public string GetMimeType(byte[] buffer, string extension)
        {
            string mime = "application/octet-stream"; // DEFAULT UNKNOWN MIME TYPE
                                                      //Get the MIME Type
            if (ByteArrayCompare(buffer, BMP))
            {
                mime = "image/bmp";
            }
            else if (ByteArrayCompare(buffer, DOC))
            {
                mime = "application/msword";
            }
            else if (ByteArrayCompare(buffer, EXE_DLL))
            {
                mime = "application/x-msdownload"; //both use same mime type
            }
            else if (ByteArrayCompare(buffer, GIF))
            {
                mime = "image/gif";
            }
            else if (ByteArrayCompare(buffer, ICO))
            {
                mime = "image/x-icon";
            }
            else if (ByteArrayCompare(buffer, JPG))
            {
                mime = "image/jpeg";
            }
            else if (ByteArrayCompare(buffer, MP3))
            {
                mime = "audio/mpeg";
            }
            else if (ByteArrayCompare(buffer, OGG))
            {
                if (extension == ".OGX") { mime = "application/ogg"; }
                else if (extension == ".OGA") { mime = "audio/ogg"; }
                else { mime = "video/ogg"; }
            }
            else if (ByteArrayCompare(buffer, PDF))
            {
                mime = "application/pdf";
            }
            else if (ByteArrayCompare(buffer, PNG))
            {
                mime = "image/png";
            }
            else if (ByteArrayCompare(buffer, RAR))
            {
                mime = "application/x-rar-compressed";
            }
            else if (ByteArrayCompare(buffer, SWF))
            {
                mime = "application/x-shockwave-flash";
            }
            else if (ByteArrayCompare(buffer, TIFF))
            {
                mime = "image/tiff";
            }
            else if (ByteArrayCompare(buffer, TORRENT))
            {
                mime = "application/x-bittorrent";
            }
            else if (ByteArrayCompare(buffer, TTF))
            {
                mime = "application/x-font-ttf";
            }
            else if (ByteArrayCompare(buffer, WAV_AVI))
            {
                mime = extension == ".AVI" ? "video/x-msvideo" : "audio/x-wav";
            }
            else if (ByteArrayCompare(buffer, WMV_WMA))
            {
                mime = extension == ".WMA" ? "audio/x-ms-wma" : "video/x-ms-wmv";
            }
            else if (ByteArrayCompare(buffer, ZIP_DOCX))
            {
                mime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
            }

            return mime;
        }
        #endregion GetMimeType
        private bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            for (int i = 0; i < a2.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }
    }
}