using System.Data;
using System.Data.SqlClient;
using Domain = TodoListActions.Domain;

namespace TodoListActions.Infrastructure
{
    public class TaskFactory
    {
        public Domain.Task GetTaskFrom(SqlDataReader reader)
        {
            Domain.Task task = Domain.Task.Create
                            (
                                reader.GetInt32("Id"),
                                reader.GetString("Description"),
                                reader.GetBoolean("Completed")
                            );
            return task;
        }
    }
}
