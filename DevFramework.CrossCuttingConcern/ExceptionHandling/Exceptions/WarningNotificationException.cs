namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class WarningNotificationException : NotificationException
    {
        public WarningNotificationException(string message) : base(message)
        {

        }

        public WarningNotificationException(string message, bool isPersisted) : base(message, isPersisted)
        {

        }

        public override string ErrorType => "warning";
    }
}