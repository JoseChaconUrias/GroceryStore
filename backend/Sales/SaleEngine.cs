namespace Sales 
{
  using System;
  using System.Collections.Generic;

  public class SaleEngine : ISaleEngine
  {
    private readonly ISaleRepository _repository;

    public SaleEngine(ISaleRepository repository) 
    {
      _repository = repository;
    }

    // Get sale by ID + validation 
    public Sale GetSaleById(int saleId) 
    {
      if (saleId <= 0)
      {
        throw new ArgumentException("Sale ID must be greater than zero.", nameof(saleId));
      }

      return _repository.GetSaleById(saleId);
    }

    // Get all sales 
    public List<Sale> GetAllSales()
    {
      return _repository.GetAllSales();
    }

    // Add new sale + validation 
    public bool AddSale(Sale sale)
    {
      ValidateSaleDates(sale.startDate, sale.endDate);

      if (sale.DiscountAmount <= 0)
      {
        throw new ArgumentException("Discount amount must be greater than zero.", nameof(sale.DiscountAmount));
      }

      return _repository.AddSale(sale);
    }

    // Update existing sale + validation 
    public bool UpdateSale(Sale sale)
    {
      if (sale.SaleID <= 0 ) 
      {
        throw new ArgumentException("Sale ID must be greater than zero.", nameof(sale.SaleID));
      }

      ValidateSaleDates(sale.startDate, sale.endDate);

      if (sale.DiscountAmount <= 0) 
      {
        throw new ArgumentException("Discount amount must be greater than zero.", nameof(sale.DiscountAmount));
      }

      return _repository.UpdateSale(sale);
    }

    // helper to validate start and end date 
    private void ValidateSaleDates(DateTime startDate, DateTime endDate) 
    {
      if (endDate < startDate)
      {
        throw new ArgumentException("End date must be greater than or equal to start date!");
      }

      if (startDate < DateTime.Now.Date)
      {
        throw new ArgumentException("Start date cannot be in the past!");
      }
    }
  }
}