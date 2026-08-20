using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces {
    public interface IToDoRepository {
        Task<IEnumerable<ToDoItemEntity>> FindAll();
        Task<ToDoItemEntity?> FindById(Guid id);
        Task<ToDoItemEntity?> FindByStatus(string status);
        Task<ToDoItemEntity?> FindByPriority(string priority);
        Task<ToDoItemEntity?> FindByDateCreated(DateTime date);
        Task<ToDoItemEntity?> FindByEndDate(DateTime date);
        Task UpdateAsync(ToDoItemEntity item);
        Task<ToDoItemEntity> Create(ToDoItemEntity item);
        Task Kill(Guid id);
    }
}