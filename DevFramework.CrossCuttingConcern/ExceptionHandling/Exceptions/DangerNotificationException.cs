namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class DangerNotificationException : NotificationException
    {
        public DangerNotificationException(string message) : base(message)
        {

        }

        public DangerNotificationException(string message, bool isPersisted) : base(message, isPersisted)
        {

        }

        public override string ErrorType => "danger";
    }
}