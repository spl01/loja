namespace Loja.API.Exceptions
{
    public class CustomObjectDuplicated : Exception
    {
        public CustomObjectDuplicated() { }

        public CustomObjectDuplicated(string message) : base(message) { }

        public CustomObjectDuplicated(string message, Exception innerException) : base(message, innerException) { }
    }
}
