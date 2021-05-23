using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace softZoneRestTask.Models
{
    [Table("user")]
    public class user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int userId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]

        public string username { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]

        public string phone { get; set; }
        [Required]
        
        [EmailAddress]
        public string email { get; set; }
        [Required]

        public string address { get; set; }

        public virtual List<order> orders { get; set; }

    }
}