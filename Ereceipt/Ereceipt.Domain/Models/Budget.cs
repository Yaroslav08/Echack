using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Domain.Models
{
    public class Budget : BaseModel<long>
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Balance { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartPeriod { get; set; }
        [Required]
        public DateTime EndPeriod { get; set; }
        public string Currency { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}