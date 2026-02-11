using App.Application.Common.Responses.Base;

namespace App.Application.Common.Responses;

public class FileResponse : BaseResponse
{
    public byte[]? File { get; init; }

    public static FileResponse Ok(byte[] file) => new() { Success = true, File = file };

    public static FileResponse Fail(params string[] errors) => new() { Success = false, Errors = errors.ToList() };
}
