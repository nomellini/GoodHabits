using GoodHabits.Database;
using GoodHabits.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.HabitsService
{
    public class HabitsService : IHabitsService
    {
        private readonly GoodHabitsDbContext _dbContext;

        public HabitsService(GoodHabitsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Habit> Create(string name, string description)
        {
            var habit = _dbContext.Habits!.Add(new Habit { Name = name, Description = description }).Entity;
            _dbContext.Todos!.Add(new Todo {  TodoItem = name });
            await _dbContext.SaveChangesAsync();
            return habit;
        }

        public async Task<IReadOnlyList<Habit>> GetAll() => await _dbContext.Habits!.ToListAsync();

        public async Task<IReadOnlyList<Todo>> GetAllItems() => await _dbContext.Todos!.ToListAsync();

        public async Task<Habit> GetById(string Id) => await _dbContext.Habits.FindAsync(Id);
    }
}
