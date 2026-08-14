namespace ChartOfAccounts.Domain.Entities;

public class Account
{
    public long Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public long? ParentId { get; set; }
    public Account? Parent { get; set; }

    public ICollection<Account> Children { get; set; }
        = new List<Account>();
    public int AccountTypeId { get; set; }

    public long Nature { get; set; }

    public bool IsPosting { get; set; }

    public bool IsActive { get; set; }
}
