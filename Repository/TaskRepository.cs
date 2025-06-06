﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Task;
using TaskSystemServer.Helpers;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksystemContext _context;
        public TaskRepository(TasksystemContext context)
        {
            _context = context;
        }
        public async Task<Models.Task> CreateAsync(Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            await _context.Entry(task).ReloadAsync();
            return task;
        }

        public async Task<Models.Task> DeleteAsync(int id)
        {
            var task = _context.Tasks.FirstOrDefault(d => d.TaskId == id);
            if (task == null)
            {
                return null;
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Models.Task> GetByTaskIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                // Return a new task or handle the situation (could throw an exception if necessary)
                throw new KeyNotFoundException("Task not found");
            }
            return task;
        }


        public async Task<List<Models.Task>> GetByIdAsync(int id, QueryObject query)
        {
            var tasks = _context.Tasks.Where(e => e.MemberId == id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                tasks = tasks.Where(d => d.Title.StartsWith(query.Title));
            }
            return await tasks.ToListAsync();
        }

        public async Task<Models.Task?> UpdateAsync(int id, UpdateTaskDto task)
        {
            var taskModel = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);
            if (taskModel == null)
            {
                return null;
            }
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.PriorityLevel = task.PriorityLevel;
            taskModel.DueDate = task.DueDate;
            taskModel.IsDone = task.IsDone;
            taskModel.RemindBeforeHours = task.RemindBeforeHours;

            await _context.SaveChangesAsync();


            // Detach the entity
            _context.Entry(taskModel).State = EntityState.Detached;

            // Reload the entity to reflect updates by the database trigger
            taskModel = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            return taskModel;
        }
    }
}
