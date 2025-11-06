namespace Solution.Database.Entities;

[Table("Item")]
public class ItemEntity
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string Name { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [ForeignKey("Account")]
    public string AccountId { get; set; }
    public AccountEntity Account { get; set; }
    public ICollection<AccountEntity> Accounts { get; set; }

}
