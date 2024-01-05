namespace Purse.DAL.Models
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
