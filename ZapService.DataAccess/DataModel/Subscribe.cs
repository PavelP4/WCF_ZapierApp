using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapService.DataAccess.DataModel
{
    public class Subscribe
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Account_Name { get; set; }

        [Required]        
        public string Target_URL { get; set; }

        [Required]
        [MaxLength(50)]
        public string Event { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public bool IsUnsubscribed { get; set; }
    }
}
