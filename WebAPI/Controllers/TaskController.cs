using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // CRUD METHODS

        // GET ALL
        [HttpGet]
        public ActionResult<List<TaskItemModel>> GetAll() => TaskService.GetAll();


        // GET BY ID
        [HttpGet("{id:int}")]
        public ActionResult<TaskItemModel> GetById(int id)
        {
            var taskItem = TaskService.GetById(id);

            if(taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // POST
        [HttpPost]
        public IActionResult Create(TaskItemModel taskItem)
        {
            TaskService.Add(taskItem);
            return CreatedAtAction(nameof(GetById), new {id = taskItem.Id}, taskItem);
        }

        // PUT
        [HttpPut]
        public IActionResult Update(int id, TaskItemModel taskItem)
        {
            if(id != taskItem.Id)
                return BadRequest();

            var existingTaskItem = TaskService.GetById(id);

            if(existingTaskItem is null)
                return NotFound();
           
            TaskService.Update(taskItem);
            return NoContent();
        }

        // DELETE
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var taskItem = TaskService.GetById(id);

            if (taskItem is null)
                return NotFound();

            TaskService.Delete(id);
            return NoContent();
        }


    }
}
