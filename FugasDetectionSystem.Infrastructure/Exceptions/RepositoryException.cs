using System;

namespace FugasDetectionSystem.Infrastructure.Exceptions
{
    // Extiende de la clase base 'Exception'
    public class RepositoryException : Exception
    {
        // Propiedad adicional en caso de que quieras incluir un código de error específico para tu repositorio
        public int ErrorCode { get; }

        // Constructor que solo toma un mensaje
        public RepositoryException(string message) : base(message)
        {
        }

        // Constructor que toma un mensaje y la excepción original
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // Constructor que toma un mensaje, un código de error y la excepción original
        public RepositoryException(string message, int errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
