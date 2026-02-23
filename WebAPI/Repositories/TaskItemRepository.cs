using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskItemRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        public async Task<List<TaskItemModel>> GetAll()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItemModel> GetById(int id)
        {
            return await _dbContext.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskItemModel> Add(TaskItemModel taskItem)
        {
            await _dbContext.TaskItems.AddAsync(taskItem);
            await _dbContext.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItemModel> Update(TaskItemModel taskItem, int id)
        {
            TaskItemModel taskById = await GetById(id);

            if (taskById == null) {
                throw new Exception($"The task for ID: {id} was not found.");
            }

            taskById.Name = taskItem.Name;
            taskById.Description = taskItem.Description;
            taskById.Status = taskItem.Status;

            _dbContext.Update(taskById);
            await _dbContext.SaveChangesAsync();
            return taskById;
        }

        public async Task<bool> Delete(int id)
        {
            TaskItemModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"The task for ID: {id} was not found.");
            }

            _dbContext.TaskItems.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
