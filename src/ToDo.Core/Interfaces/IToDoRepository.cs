using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces {
    public interface IToDoRepository {
        Task<IEnumerable<ToDoItemEntity>> FindAll();
        Task<ToDoItemEntity?> FindById(Guid id);
        Task<IEnumerable<ToDoItemEntity?>> FindByStatus(string status);
        Task<IEnumerable<ToDoItemEntity?>> FindByPriority(string priority);
        Task<IEnumerable<ToDoItemEntity?>> FindByDateCreated(DateTime date);
        Task<IEnumerable<ToDoItemEntity?>> FindByEndDate(DateTime date);
        Task Update(ToDoItemEntity item);
        Task Create(ToDoItemEntity item);
        Task Kill(Guid id);
    }
}