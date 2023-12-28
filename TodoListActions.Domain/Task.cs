namespace TodoListActions.Domain
{
    public class Task
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public bool Completed { get; private set; }

        public static Task Create(string description)
        {
            return new Task()
            {
                Description = description,
                Completed = false
            };
        }

        public static Task Create(int id, string description, bool completed)
        {
            Task task;
            task = Create(description);
            task.Id = id;
            task.Completed = completed;
            return task;
        }
    }
}
