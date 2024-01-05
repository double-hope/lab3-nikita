namespace Purse.DAL.Models
{
    public class Expense : BaseEntity
    {
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Guid CostItemId { get; set; }
        public virtual CostItem CostItem { get; set; }
    }
}
