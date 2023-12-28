namespace TodoListActions.Application
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Domain.Task>> GetAllTasks();
        Task<Domain.Task> GetTaskById(int id);
    }
}
