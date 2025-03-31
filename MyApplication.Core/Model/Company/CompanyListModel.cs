using System;
using System.ComponentModel.DataAnnotations;
using MyApplication.Core.Model;

namespace MyApplication.Core
{
    public class CompanyModel : KeyModel
    {
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
        public string  PhoneNo { get; set; }
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
    }
    public class CompanyListModel : CompanyModel
    {

    }
}
