using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace softZoneRestTask.Models
{
    public class userOrder
    {
        public user user { get; set; }
        public List<Item> items { get; set; }
    }
}