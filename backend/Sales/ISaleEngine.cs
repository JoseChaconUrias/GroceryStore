namespace Sales{
  public interface ISaleEngine 
  {
    Sale GetSaleById(int saleId);
    List<Sale> GetAllSales();
    bool AddSale(Sale sale);
    bool UpdateSale(Sale sale);
  }
}