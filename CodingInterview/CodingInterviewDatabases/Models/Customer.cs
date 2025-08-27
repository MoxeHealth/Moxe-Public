namespace CodingInterview.Databases;

[ExcludeFromCodeCoverage]
public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public ICollection<Invoice> Invoices { get; set; }
}
