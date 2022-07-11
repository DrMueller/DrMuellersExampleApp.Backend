namespace Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Eithers.Implementation
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TLeft Content { get; }

        public Left(TLeft content)
        {
            Content = content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left)
        {
            return left.Content;
        }

        public TLeft ToTLeft()
        {
            return Content;
        }
    }
}