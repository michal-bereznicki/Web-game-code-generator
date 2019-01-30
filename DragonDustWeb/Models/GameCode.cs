using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DragonDustWeb.Models
{
    public class GameCode
    {
        public int Id { get; set; }
        public int GameId { get; set; }

        public string Code { get; set; }
        [Required]
        public bool Used { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

    }
}