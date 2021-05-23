using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace softZoneRestTask.Models
{
    [Table("city")]

    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityId { set; get; }

        [Required]
        public string cityName { get; set; }

        public virtual List<RestInfo> restInfos { get; set; }
    }
}