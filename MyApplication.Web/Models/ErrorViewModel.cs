namespace MyApplication.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string ExceptionPath { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string Source { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
