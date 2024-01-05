namespace Purse.DAL.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
