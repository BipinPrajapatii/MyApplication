using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyApplication.Data.Entities;

namespace MyApplication.Data.Entities
{
    public class Company : AuditedEntity
    {
        public Company()
        {
            AppUsers = new HashSet<User>();
            //Tasks = new HashSet<TaskDetail>();
            //Projects = new HashSet<Project>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxUser { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string PhoneNo { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string ZipCode { get; set; }
        [MaxLength(1000)]
        public string Address1 { get; set; }
        [MaxLength(1000)]
        public string Address2 { get; set; }
        public DateTime? LastSyncedDateTime { get; set; }
        public virtual ICollection<User> AppUsers { get; set; }
        //public virtual AccessReportSetting AccessReportSetting { get; set; }
        //public virtual ICollection<TaskDetail> Tasks { get; set; }
        //public virtual ICollection<Project> Projects { get; set; }
    }
}
