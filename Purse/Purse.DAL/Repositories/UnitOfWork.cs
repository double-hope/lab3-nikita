using Purse.DAL.Interfaces;
using Purse.DAL.Models;

namespace Purse.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private IRepository<Account> accountRepository;
        private IRepository<CostItem> costItemRepository;
        private IRepository<Expense> expenseRepository;
        private IRepository<Income> incomeRepository;
        private IRepository<User> userRepository;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IRepository<Account> AccountRepository
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new Repository<Account>(_context);
                }
                return accountRepository;
            }
        }

        public IRepository<CostItem> CostItemRepository
        {
            get
            {
                if (costItemRepository == null)
                {
                    costItemRepository = new Repository<CostItem>(_context);
                }
                return costItemRepository;
            }
        }

        public IRepository<Expense> ExpenseRepository
        {
            get
            {
                if (expenseRepository == null)
                {
                    expenseRepository = new Repository<Expense>(_context);
                }
                return expenseRepository;
            }
        }

        public IRepository<Income> IncomeRepository
        {
            get
            {
                if (incomeRepository == null)
                {
                    incomeRepository = new Repository<Income>(_context);
                }
                return incomeRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(_context);
                }
                return userRepository;
            }
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
