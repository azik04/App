using App.Application.Common.Responses.Base;

namespace App.Application.Common.Responses;

public class GenericResponse<T> : BaseResponse
{
    public T? Data { get; set; }

    public static GenericResponse<T> Ok(T data)
    {
        return new GenericResponse<T>
        {
            Data = data,
            Success = true,
            Message = "Success"
        };
    }

    public static GenericResponse<T> Fail(params string[] errors)
    {
        return new GenericResponse<T>
        {
            Success = false,
            Errors = errors.ToList()
        };
    }
}
