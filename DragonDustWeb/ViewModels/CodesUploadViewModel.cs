using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonDustWeb.ViewModels
{
    public class CodesUploadViewModel
    {
        public IEnumerable GameIds { get; set; }
        public IEnumerable GameNames { get; set; }
        public DateTime CodesExpireDate { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}