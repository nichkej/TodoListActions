using Domain = TodoListActions.Domain;

namespace TodoListActions.Application
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Task>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<Domain.Task> GetTaskById(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }
    }
}
