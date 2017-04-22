namespace ArEnMVCTemplate
{
    public class Alert
    {
        public string Message { get; set; }

        public MessageTypes MessageType { get; set; }
    }

    public enum MessageTypes
    {
        InfoCode = 1,
        SuccessCode = 2,
        WarningCode = 3,
        ErrorCode = 4
    }
}