using Microsoft.AspNetCore.Mvc;
using Mmu.DrMuellersExampleApp.CrossCutting.Errors;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.DrMuellersExampleApp.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Dtos;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.ActionResults;

public static class ActionResultAdapters
{
    public static IActionResult ToActionResult(this Maybe<ServerError> err)
    {
        if (err is None<ServerError>) return new OkResult();

        return CreateBadRequest(err.ReduceThrow());
    }

    public static IActionResult ToActionResult<T>(this Maybe<T> maybe)
    {
        return maybe
            .Map<T, IActionResult>(f => new OkObjectResult(f))
            .Reduce(() => new NoContentResult());
    }

    public static IActionResult ToActionResult<TRight>(this Either<ServerError, TRight> either)
    {
        return either
            .MapRight(obj => (IActionResult) new OkObjectResult(obj))
            .ReduceRight(CreateBadRequest);
    }

    private static BadRequestObjectResult CreateBadRequest(ServerError err)
    {
        return new BadRequestObjectResult(
            new ErrorDto
            {
                Message = err.ToDescription()
            });
    }
}