namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public abstract class NotificationException : System.Exception
    {
        protected NotificationException(string message) : base(message)
        {

        }

        protected NotificationException(string message, bool isPersisted) : base(message)
        {
            IsPersisted = isPersisted;
        }

        public abstract string ErrorType { get; }

        public virtual bool IsPersisted { get; private set; }
    }
}
