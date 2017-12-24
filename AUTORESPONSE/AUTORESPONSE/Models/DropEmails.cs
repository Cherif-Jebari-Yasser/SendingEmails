using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTORESPONSE.Models
{
    public class DropEmails
    {
        public string fromName { get; set; }
        public string sendTo { get; set; }
        public string subject { get; set; }
        [AllowHtmlAttribute]
        public string creative { get; set; }
        public string data { get; set; }

        public DropEmails()
        {

        }
    }
}