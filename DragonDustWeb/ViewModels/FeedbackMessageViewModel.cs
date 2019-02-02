using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonDustWeb.ViewModels
{
    public enum FeedbackMessageType
    {
        Confirmation,
        Error,
        Info
    }

    public class FeedbackMessageViewModel
    {
        public string Message { get; set; }
        public FeedbackMessageType MessageType { get; set; }
    }
}