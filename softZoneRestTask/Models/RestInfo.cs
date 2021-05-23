using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace softZoneRestTask.Models
{
    [Table("restInfo")]

    public class RestInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int restId { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string image { get; set; }

        [ForeignKey("City")]
        public int cityId { get; set; }

        public virtual City City { get; set; }

        public virtual List<Item> items  { get; set; }

    }
}