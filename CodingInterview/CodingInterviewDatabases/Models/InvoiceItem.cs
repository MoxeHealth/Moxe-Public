namespace CodingInterview.Databases;

[ExcludeFromCodeCoverage]
public class InvoiceItem
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("InvoiceId")]
    public virtual Invoice Invoice { get; set; }
    [ForeignKey("ItemId")]
    public virtual Item Item { get; set; }
}