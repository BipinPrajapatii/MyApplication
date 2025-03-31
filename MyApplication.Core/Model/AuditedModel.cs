using System;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Model
{
    public class AuditedModel
    {
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}