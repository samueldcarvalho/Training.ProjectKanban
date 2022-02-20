using System.ComponentModel.DataAnnotations;

namespace Training.Kanban.Core.Domain.Exceptions
{
    public class Validation
    {
        public static void ValidarSeIgual(object a, object b, string message)
        {
            if (!a.Equals(b))
                throw new DomainException(message);
        }

        public static void ValidaEmail(string email, string message)
        {
            if (!new EmailAddressAttribute().IsValid(email))
                throw new DomainException(message);
        }

        public static void ValidarSeDiferente(object a, object b, string message)
        {
            if (a.Equals(b))
                throw new DomainException(message);
        }

        public static void ValidarStringEspacoEVazio(string a, string message)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a))
                throw new DomainException(message);
        }

        public static void ValidarStringApenasVazio(string a, string message)
        {
            if (string.IsNullOrEmpty(a))
                throw new DomainException(message);
        }

        public static void ValidarStringTamanho(string valor, int minimo, int maximo, string message)
        {
            if (valor.Length < minimo || valor.Length > maximo)
                throw new DomainException(message);
        }

        public static void ValidarStringTamanhoMinimo(string valor, int minimo, string message)
        {
            if (valor.Length < minimo)
                throw new DomainException(message);
        }

        public static void ValidarStringTamanhoMaximo(string valor, int maximo, string message)
        {
            if (valor.Length > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMinimoMaximo(double valor, long minimo, long maximo, string message)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMinimoMaximo(int valor, long minimo, long maximo, string message)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMinimoMaximo(float valor, long minimo, long maximo, string message)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string message)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMinimo(float valor, long minimo, string message)
        {
            if (valor < minimo)
                throw new DomainException(message);
        }

        public static void ValidarMinimo(int valor, long minimo, string message)
        {
            if (valor < minimo)
                throw new DomainException(message);
        }

        public static void ValidarMinimo(double valor, long minimo, string message)
        {
            if (valor < minimo)
                throw new DomainException(message);
        }

        public static void ValidarMinimo(long valor, long minimo, string message)
        {
            if (valor < minimo)
                throw new DomainException(message);
        }

        public static void ValidarMaximo(float valor, long maximo, string message)
        {
            if (valor > maximo)
                throw new DomainException(message);
        }

        public static void ValidarMaximo(int valor, long maximo, string message)
        {
            if (valor > maximo)
                throw new DomainException(message);
        }
        public static void ValidarMaximo(double valor, long maximo, string message)
        {
            if (valor > maximo)
                throw new DomainException(message);
        }
        public static void ValidarMaximo(long valor, long maximo, string message)
        {
            if (valor > maximo)
                throw new DomainException(message);
        }
    }
}
