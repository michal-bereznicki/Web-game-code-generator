using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DragonDustWeb.ViewModels
{
    public class EmailViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public int RequestedGameId { get; set; }
    }
}