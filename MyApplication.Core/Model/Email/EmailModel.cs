namespace MyApplication.Core.Model.Email
{
    public class EmailModel
    {

        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsBodyHtml { get; set; }

        public EmailModel(string to, string subject, string message, bool isBodyHtml)
        {
            To = to;
            Subject = subject;
            Message = message;
            IsBodyHtml = isBodyHtml;
        }
    }


}
