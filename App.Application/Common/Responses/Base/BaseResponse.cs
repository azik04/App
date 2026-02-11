namespace App.Application.Common.Responses.Base;

public abstract class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string>? Errors { get; set; }


    protected void SetSuccess()
    {
        Success = true;
        Message = "Success";
    }

    protected void SetError(params string[] errors)
    {
        Success = false;
        Errors = errors.ToList();
    }
}
