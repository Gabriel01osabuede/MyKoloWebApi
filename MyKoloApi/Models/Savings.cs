using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyKoloApi.Models
{
    public class Savings
    {
        //id,Amount,Description,CreatedDate,LastModeifiedDate

        [Key]
        public string Id { get; set; }
        public virtual User user { get; set; }
        public string UserId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
    }
}
