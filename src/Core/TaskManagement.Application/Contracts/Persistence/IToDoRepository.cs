using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> ToDoListByDate(DateTime date, int page, int size);
        Task<int> GetTotalCountOfToDoByDate(DateTime date);
    }
}
