namespace App.Application.Common.Responses;

public class PaginatedResponse<T> : GenericResponse<IEnumerable<T>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }

    public bool HasNextPage => PageNumber * PageSize < TotalCount;
    public bool HasPrevPage => PageNumber > 1;
}

