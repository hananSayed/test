using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace softZoneRestTask.Models
{
    [Table("order")]

    public class order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int orderId { get; set; }

        public int itemCount { get; set; }

        [ForeignKey("item")]
        public int itemId { get; set; }

        public virtual Item item { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }

        public virtual user user { get; set; }


    }
}