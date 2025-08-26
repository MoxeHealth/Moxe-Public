namespace CodingInterview.Databases;

[ExcludeFromCodeCoverage]
public class Item
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Unit { get; set; }
    public double Price { get; set; }
    public double Taxes { get; set; }
}