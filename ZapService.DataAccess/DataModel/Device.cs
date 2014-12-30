using System;
using System.ComponentModel.DataAnnotations;


namespace ZapService.DataAccess.DataModel
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
