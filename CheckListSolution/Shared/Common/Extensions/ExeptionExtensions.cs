namespace Common.Extensions;

using Common.Responses;

public static class ErrorResponseExtensions
{
       public static ErrorResponse ToErrorResponse(this Exception data)
    {
        var res = new ErrorResponse()
        {
            // ToDo: create logic for error's code (can't create)
            ErrorCode = -1,
            Message = data.Message
        };

        return res;
    }
}