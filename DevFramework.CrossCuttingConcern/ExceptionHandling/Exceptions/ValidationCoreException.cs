namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class ValidationCoreException :DangerNotificationException
    {
        public ValidationCoreException(string message) : base(message)
        {

        }
    }
}