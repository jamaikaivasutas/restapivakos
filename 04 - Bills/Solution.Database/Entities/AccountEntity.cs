namespace Solution.Database.Entities;

[Table("Account")]
public class AccountEntity
{
    [Key]
    public string AccountNumber { get; set; }

    [Required]
    public DateTime DateOfCreation { get; set; }

    [Required]
    public int SumOfItemPrices { get; set; }

    public ICollection<ItemEntity> Items { get; set; }
}
