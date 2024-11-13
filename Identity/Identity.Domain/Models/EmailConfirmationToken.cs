using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class EmailConfirmationToken
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        [StringLength(250)]
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

}
