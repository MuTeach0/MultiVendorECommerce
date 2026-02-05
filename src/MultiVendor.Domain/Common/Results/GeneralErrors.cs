using MultiVendor.Domain.Common.Constants;

namespace MultiVendor.Domain.Common.Results;

public static class GeneralErrors
{
    public static Error UnProcessableRequest => Error.Failure("General.UnProcessableRequest", GeneralMessages.UnexpectedError);
    public static Error ValidationError => Error.Validation("General.Validation", GeneralMessages.ValidationError);
    public static Error NotFound => Error.NotFound("General.NotFound", GeneralMessages.ResourceNotFound);
    public static Error Unauthorized => Error.Unauthorized("General.Unauthorized", GeneralMessages.Unauthorized);
    public static Error Forbidden => Error.Forbidden("General.Forbidden", GeneralMessages.Forbidden);
}