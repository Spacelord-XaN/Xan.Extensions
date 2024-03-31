namespace Xan.Extensions.Collections;

public interface IPaginated
{
    public const int AllPageSize = 0;

    public static int CalcTotalPages(int totalItemCount, int pageSize)
    {
        if (pageSize > AllPageSize)
        {
            return (int)Math.Ceiling(totalItemCount / (double)pageSize);

        }
        return 1;
    }

    public int PageIndex { get; }

    public int PageSize { get; }

    public int TotalPageCount { get; }

    public int TotalItemCount { get; }

    public bool HasPreviousPage
    {
        get => PageIndex > 1;
    }

    public bool HasNextPage
    {
        get => PageIndex < TotalPageCount;
    }
}
