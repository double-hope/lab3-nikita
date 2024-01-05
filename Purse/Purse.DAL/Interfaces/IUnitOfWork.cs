using Purse.DAL.Models;

namespace Purse.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Account> AccountRepository { get; }
        IRepository<CostItem> CostItemRepository { get; }
        IRepository<Expense> ExpenseRepository { get; }
        IRepository<Income> IncomeRepository { get; }
        IRepository<User> UserRepository { get; }
        Task SaveAsync();
    }
}
