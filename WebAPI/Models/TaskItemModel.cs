using WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class TaskItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskItemStatus Status { get; set; }
    }
}
