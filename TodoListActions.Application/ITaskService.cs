namespace TodoListActions.Application
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Task>> GetAllTasks();
        Task<Domain.Task> GetTaskById(int id);
    }
}
