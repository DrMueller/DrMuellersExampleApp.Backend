using System.Diagnostics.CodeAnalysis;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;

namespace Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Maybes;

public static class Maybe
{
    public static Maybe<T> CreateFromNullable<T>(T? possiblyNull)
    {
        return possiblyNull == null ? CreateNone<T>() : possiblyNull;
    }

    public static Maybe<T> CreateNone<T>()
    {
        return new None<T>();
    }

    // Helps to avoid some conversation complexities
    public static Maybe<T> CreateSome<T>(T obj)
    {
        return obj;
    }
}

[SuppressMessage(
    "StyleCop.CSharp.MaintainabilityRules",
    "SA1402:FileMayOnlyContainASingleClass",
    Justification = "It makes sense to keep these Classes together")]
public abstract class Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
{
    public abstract bool Equals(Maybe<T>? other);

    public abstract bool Equals(T? other);

    public static bool operator ==(Maybe<T>? a, Maybe<T>? b)
    {
        if (ReferenceEquals(null, a) && ReferenceEquals(null, b)) return true;

        if (!ReferenceEquals(null, a) && !ReferenceEquals(null, b) && a.Equals(b)) return true;

        return false;
    }

    public static bool operator ==(Maybe<T>? a, T b)
    {
        return !ReferenceEquals(null, a) && a.Equals(b);
    }

    public static implicit operator Maybe<T>(T value)
    {
        return new Some<T>(value);
    }

    // ReSharper disable once UnusedParameter.Global
    public static implicit operator Maybe<T>(None none)
    {
        return new None<T>();
    }

    public static bool operator !=(Maybe<T> a, Maybe<T> b)
    {
        return !(a == b);
    }

    public static bool operator !=(Maybe<T> a, T b)
    {
        return !(a == b!);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;

        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((Maybe<T>) obj);
    }

    public abstract override int GetHashCode();

    // ReSharper disable once UnusedMember.Global
    public Maybe<T> ToMaybe()
    {
        return new None<T>();
    }
}