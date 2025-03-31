using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Core.Model.User
{
    public class UserListModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime? StartTime { get; set; }
        //public DateTime? StartBreak { get; set; }
        //public DateTime? EndBreak { get; set; }
        public int WorkTime { get; set; }
        public int BreakTime { get; set; }
        public int AwayTime { get; set; }
        //public int TaskId { get; set; }
        //public IEnumerable<UserListRangedModel> RangedTimes { get; set; }

    }

    public class UserTaskListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
    }

    public class UserScreenshotListModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
    }

    public class UserAppListModel
    {
        public string AppUsed { get; set; }
        public int Duration { get; set; }
    }

    public class UserDateListModel
    {
        public int Id { get; set; }
        public DateTime TrackedOn { get; set; }
        //public DateTime TrackedEnd { get; set; }
        public string Activity { get; set; }
        public int Duration { get; set; }
        public int WorkTime { get; set; }
        public int BreakTime { get; set; }
        public int AwayTime { get; set; }
    }
}
