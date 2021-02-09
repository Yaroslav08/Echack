using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Echack.Domain.Models
{

    public class BaseModel
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
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