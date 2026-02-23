using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItemModel>> GetAll();
        Task<TaskItemModel> GetById(int id);
        Task<TaskItemModel> Add(TaskItemModel taskItem);
        Task<TaskItemModel> Update(TaskItemModel taskItem, int id);
        Task<bool> Delete(int id);
    }
}
