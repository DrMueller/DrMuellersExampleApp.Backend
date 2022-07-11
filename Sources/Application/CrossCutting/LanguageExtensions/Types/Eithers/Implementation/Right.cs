namespace Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Eithers.Implementation
{
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TRight Content { get; }

        public Right(TRight content)
        {
            Content = content;
        }

        public static implicit operator TRight(Right<TLeft, TRight> right)
        {
            return right.Content;
        }

        // ReSharper disable once UnusedMember.Global
        public TRight ToTRight(Right<TLeft, TRight> right)
        {
            return right.Content;
        }
    }
}