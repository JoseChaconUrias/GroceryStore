namespace Sales 
{
  public class Sale 
  {
    public required int SaleID { get; set; }
    public required DateTime startDate { get; set; }
    public required DateTime endDate { get; set;}
    public required bool IsPercentage { get; set; }
    public required double DiscountAmount {get; set;}
  }
}
