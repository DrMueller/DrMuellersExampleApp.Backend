namespace Mmu.DrMuellersExampleApp.CrossCutting.Errors;

public abstract class ServerError
{
    public abstract string ToDescription();
}