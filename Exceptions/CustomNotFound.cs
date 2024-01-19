namespace Loja.API.Exceptions
{
    public class CustomNotFound : Exception
    {
        public CustomNotFound() { }

        public CustomNotFound(string message) : base(message) { }

        public CustomNotFound(string message, Exception innerException) : base(message, innerException) { }

    }
}
