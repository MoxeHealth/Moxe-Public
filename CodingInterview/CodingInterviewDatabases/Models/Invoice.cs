namespace CodingInterview.Databases;

[ExcludeFromCodeCoverage]
public class Invoice
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Paid { get; set; }
    public DateTime? Shipped { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; }

    public IDictionary<string, double> ItemizedTotal
        => OrderData.ToDictionary(x => x.Key, x => Math.Round(x.Value.Quantity * x.Value.Price, 2));
    public double Subtotal
        => Math.Round(OrderData.Values.Sum(x => x.Quantity * x.Price), 2);
    public double Taxes
        => Math.Round(OrderData.Values.Sum(x => x.Quantity * x.Price * x.Taxes), 2);
    public double TotalPrice
        => Math.Round(Subtotal + Taxes, 2);
    private IDictionary<string, (int Quantity, string Name, double Price, double Taxes)> OrderData
        => InvoiceItems?.Select(x => (x.Quantity, x.Item.Name, x.Item.Price, x.Item.Taxes)).GroupBy(x => x.Name).ToDictionary(x => x.Key, x => x.First());
}