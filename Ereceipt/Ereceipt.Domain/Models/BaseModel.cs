using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ereceipt.Domain.Models
{

    public class BaseModel
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }


        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class BaseModel<TypeId> : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TypeId Id { get; set; }
    }

    public class BaseModelWithIdentityGen<TypeId> : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TypeId Id { get; set; }
    }
}