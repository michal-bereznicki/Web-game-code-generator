using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonDustWeb.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GooglePlayPageLink { get; set; }


        public static readonly int AncientTombAdventureId = 1;
        public static readonly int KidsMusicComposerId = 2;
    }
}