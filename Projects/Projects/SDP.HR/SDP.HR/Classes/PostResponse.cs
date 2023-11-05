using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDP.HR.Classes
{
    public class PostResponse
    {
        public bool success;
        public ControlError[] errors;
        public string message = string.Empty;
    }

}