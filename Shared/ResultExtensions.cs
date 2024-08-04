using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Shared;

public static class ResultExtensions
{
    public static ActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }
        else
        {
            return new BadRequestObjectResult(result.Error);
        }
    }

    public static ActionResult ToActionResult<T>(this Result<T> result, Func<T, ActionResult> onSuccess)
    {
        if (result.IsSuccess)
        {
            return onSuccess(result.Value);
        }
        else
        {
            return new BadRequestObjectResult(result.Error);
        }
    }
}
