using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Data;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;

namespace ToDo.Infrastructure.Repositories;

public class ToDoRepository : IToDoRepository {
    private readonly BankContext _context;

    public ToDoRepository(BankContext context) {
        _context = context;
    }

    public async Task<IEnumerable<ToDoItemEntity>> FindAll() {
        return await _context.ToDoItem.ToListAsync();
    }

    public async Task<ToDoItemEntity?> FindById(Guid id) {
        return await _context.ToDoItem.FindAsync(id);
    }

    public async Task<IEnumerable<ToDoItemEntity?>> FindByStatus(string status) {
        return await _context.ToDoItem.Where(item => item.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<ToDoItemEntity?>> FindByPriority(string priority) {
        return await _context.ToDoItem.Where(item => item.Priority == priority).ToListAsync();
    }

    public async Task<IEnumerable<ToDoItemEntity?>> FindByDateCreated(DateTime date) {
        return await _context.ToDoItem.Where(item => item.CreatedAt == date).ToListAsync();
    }

    public async Task<IEnumerable<ToDoItemEntity?>> FindByEndDate(DateTime date) {
        return await _context.ToDoItem.Where(item => item.DeadlineAt == date).ToListAsync();
    }

    public async Task Update(ToDoItemEntity item) {
        ToDoItemEntity itemDb = await FindById(item.Id);

        if (itemDb == null) {
            return;
        }

        _context.ToDoItem.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task Create(ToDoItemEntity item) {
        ToDoItemEntity itemDb = await FindById(item.Id);

        if (itemDb != null) {
            return;
        }

        await _context.Set<ToDoItemEntity>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Kill(Guid id) {
        ToDoItemEntity item = await FindById(id);

        if (item == null) {
            return;
        }

        _context.ToDoItem.Remove(item);
        await _context.SaveChangesAsync();
    }
}
