namespace Solution.Database.Entities;

[Table("Chocolate")]
public class ChocolateEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(128)]
    [Required]
    public string Flavor { get; set; }

    [Required]
    public int Price { get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }

    public virtual BrandEntity Brand { get; set; }
}
