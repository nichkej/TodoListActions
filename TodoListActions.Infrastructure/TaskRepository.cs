using System.Data.SqlClient;
using TodoListActions.Application;

namespace TodoListActions.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskFactory _taskFactory;
        private readonly ConnectionFactory _connectionFactory;

        public TaskRepository(TaskFactory taskFactory, ConnectionFactory connectionFactory)
        {
            _taskFactory = taskFactory;
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Domain.Task>> GetAllTasks()
        {
            List<Domain.Task> tasks = new List<Domain.Task>();
            using SqlConnection _connection = _connectionFactory.GetConnection();
            await _connection.OpenAsync();
            using SqlCommand command = new SqlCommand("SELECT * FROM Tasks", _connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    tasks.Add(_taskFactory.GetTaskFrom(reader));
                }
            }
            return tasks;
        }

        public async Task<Domain.Task> GetTaskById(int id)
        {
            using SqlConnection _connection = _connectionFactory.GetConnection();
            await _connection.OpenAsync();
            using SqlCommand command = new SqlCommand("SELECT * FROM Tasks WHERE Id = @Id", _connection);
            command.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                return _taskFactory.GetTaskFrom(reader);
            }
            return null;
        }
    }
}
