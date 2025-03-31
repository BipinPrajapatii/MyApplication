using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApplication.Data.Entities
{
    public class History : Entity
    {
        public DateTime CreatedOn { get; set; }

        [MaxLength(10)]
        public string Activity { get; set; }

        [MaxLength(100)][ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
