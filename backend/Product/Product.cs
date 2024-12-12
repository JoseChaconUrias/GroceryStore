namespace Product
{
  public class Product
  {
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Images { get; set; }
    public string Manufacturer { get; set; }
    public string Dimensions { get; set; }
    public double Weight { get; set; }
    public double Rating { get; set; }
    public string SKU { get; set; }
    public int CategoryID { get; set; }
    public int Stock { get; set; }
    public int? SaleID { get; set; }
    public double DiscountedPrice { get; set; }
  }
}