using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyKoloApi.Models
{
    public class User
    {
        //Id,Username,Password,CreatedDate,ModifiedDate,Email,PhoneNumber
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual IEnumerable<Savings> Savings { get; set; }
        public virtual IEnumerable<Expense> Expenses { get; set; }

    }
}
