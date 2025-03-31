using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Core.Model.Account
{
    public class HistoryModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Activity { get; set; }
        public string UserId { get; set; }
    }
}
