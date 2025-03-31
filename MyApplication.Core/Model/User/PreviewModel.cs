using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Model.User
{
    public class PreviewModel
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public string UserId { get; set; }
        public int Screenshots { get; set; }
        public List<string> Tasks { get; set; }
        public List<string> Apps { get; set; }
        public TimeSpan? WorkTime { get; set; }
        public TimeSpan? BreakTime { get; set; }
        public double Earning { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
