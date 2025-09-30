using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Errors;

public class ModelStateInvalidError : ProblemDetails
{

    public ModelStateInvalidError(string reason, string[] errors): base()
    {
        this.Status = StatusCodes.Status400BadRequest;
        this.Detail = reason;
        this.Extensions.Add("ModelErrors", errors);
    }
}