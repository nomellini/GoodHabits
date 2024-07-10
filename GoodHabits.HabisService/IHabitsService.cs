using GoodHabits.Database.Entities;

namespace GoodHabits.HabitsService
{
    public interface IHabitsService
    {
        Task<Habit> Create(string name, string description);
        Task<Habit> GetById(string Id);
        Task<IReadOnlyList<Habit>> GetAll();

    }
}
