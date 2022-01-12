using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(TaskManagementDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<ToDo>> ToDoListByDate(DateTime date, int page, int size) =>
            await dbSet.Where(x => x.DeadLine.Date == date.Date)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsync();

        public async Task<int> GetTotalCountOfToDoByDate(DateTime date) =>
            await dbSet.CountAsync(x => x.DeadLine.Date == date.Date);
    }
}
