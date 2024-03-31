namespace Xan.Extensions.Collections.Generic;

public interface IPaginatedList<T>
    : IReadOnlyList<T>
    , IPaginated
{
}