using System;

namespace MyApplication.Core.Model.Account
{
    public class JsonWebTokenModel
    {
        public DateTime Expired { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
