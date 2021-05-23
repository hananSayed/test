using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace softZoneRestTask.Models
{
    [Table("item")]

    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int itemId { get; set; }

        public string itemName { get; set; }

        public string desription { get; set; }

        public int price { get; set; }

        public string image { get; set; }

        [ForeignKey("restInfo")]
        public int restId { get; set; }

        public virtual RestInfo restInfo { get; set; }
    }
}