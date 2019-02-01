using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DragonDustWeb.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public int GameId { get; set; }

        public int OrderType { get; set; }
        [Required]
        public byte OrderTypeId { get; set; }
    }
}