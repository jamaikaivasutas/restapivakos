namespace Solution.Database.Entities;

[Table("Brand")]
[Index(nameof(Name), IsUnique = true)]
public class BrandEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(64)]
    [Required]
    public string Name { get; set; }
    public virtual ICollection<ChocolateEntity> Chocolates { get; set; }
}
