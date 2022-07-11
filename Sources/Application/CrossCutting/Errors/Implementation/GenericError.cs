using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Invariance;

namespace Mmu.CleanDddSimple.CrossCutting.Errors.Implementation
{
    public class GenericError : ServerError
    {
        public string ErrorMessage { get; }

        public GenericError(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);

            ErrorMessage = errorMessage;
        }

        public override string ToDescription()
        {
            return ErrorMessage;
        }
    }
}