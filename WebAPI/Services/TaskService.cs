using WebAPI.Models;

namespace WebAPI.Services
{
    public static class TaskService
    {
        static List<TaskItemModel> TasksItems { get; }
        static int nextId = 3;

        static TaskService()
        {
            TasksItems = new List<TaskItemModel>
        {
            new TaskItemModel { Id = 1, Name = "Estudar ASP.NET Core", Status = 1 },
            new TaskItemModel { Id = 2, Name = "Implementar CRUD", Status = 1 }
        };
        }

        public static List<TaskItemModel> GetAll() => TasksItems;

        public static TaskItemModel? GetById(int id) => TasksItems.FirstOrDefault(t => t.Id == id);

        public static void Add(TaskItemModel taskItem)
        {
            taskItem.Id = nextId++;
            TasksItems.Add(taskItem);
        }

        public static void Delete(int id)
        {
            var taskItem = GetById(id);
            if (taskItem is null)
                return;

            TasksItems.Remove(taskItem);
        }

        public static void Update(TaskItemModel taskItem)
        {
            var index = TasksItems.FindIndex(t => t.Id == taskItem.Id);
            if (index == -1)
                return;

            TasksItems[index] = taskItem;
        }
    }
}
