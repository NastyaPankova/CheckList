namespace Common.Extensions;

using Common.Responses;

public static class ErrorResponseExtensions
{
       public static ErrorResponse ToErrorResponse(this Exception data)
    {
        var res = new ErrorResponse()
        {
            // CHANGE: create logic for error's code
            ErrorCode = -1,
            Message = data.Message
        };

        return res;
    }
}