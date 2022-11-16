namespace Xan.Extensions.Tasks;

public interface IBackgroundTaskQueue
{
    void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

    Task<Func<CancellationToken, Task>?> DequeueAsync(CancellationToken cancellationToken);
}
