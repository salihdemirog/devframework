namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class ValidationCoreException : ErrorNotificationException
    {
        public ValidationCoreException(string message) : base(message)
        {

        }
    }
}