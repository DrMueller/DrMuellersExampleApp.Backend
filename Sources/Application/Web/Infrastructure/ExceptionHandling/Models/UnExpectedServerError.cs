using JetBrains.Annotations;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Invariance;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.ExceptionHandling.Models
{
    [PublicAPI]
    public class UnExpectedServerError
    {
        public string Message { get; }
        public string StackTrace { get; }
        public string TypeName { get; }

        private UnExpectedServerError(string message, string typeName, string stackTrace)
        {
            Guard.StringNotNullOrEmpty(() => message);
            Guard.StringNotNullOrEmpty(() => typeName);

            Message = message;
            TypeName = typeName;
            StackTrace = stackTrace;
        }

        public static UnExpectedServerError CreateFromException(Exception exception)
        {
            Guard.ObjectNotNull(() => exception);

            var mostInnerEx = GetMostInnerException(exception);

            return new UnExpectedServerError(
                mostInnerEx.Message,
                mostInnerEx.GetType().Name,
                mostInnerEx.StackTrace ?? "No Stacktrace");
        }

        private static Exception GetMostInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}