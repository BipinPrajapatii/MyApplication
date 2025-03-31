using MyApplication.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApplication.Data.Entities
{
    public class AuditedEntity : Entity
    {
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        [Column("CreatedOn", TypeName = "DateTime")]
        public DateTime? CreatedOn { get; set; }
        [MaxLength(100)]
        public string? UpdatedBy { get; set; }
        [Column("UpdatedOn", TypeName = "DateTime")]
        public DateTime? UpdatedOn { get; set; }
    }
}
