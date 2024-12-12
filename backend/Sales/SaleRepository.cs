namespace Sales
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;

    public class SaleRepository : ISaleRepository
    {
      private string _connectionString;
      public SaleRepository(string connectionString)
      {
          _connectionString = connectionString;
      }

      // Get sale by ID
      public Sale GetSaleById(int saleId)
      {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
          connection.Open();

          string query = "SELECT * FROM Sale WHERE SaleID = @SaleID";
          using (SqlCommand cmd = new SqlCommand(query, connection))
          {
            cmd.Parameters.AddWithValue("@SaleID", saleId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              if (reader.Read())
              {
                return new Sale
                {
                  SaleID = reader.GetInt32(reader.GetOrdinal("SaleID")),
                        startDate = reader.GetDateTime(reader.GetOrdinal("startDate")),
                        endDate = reader.GetDateTime(reader.GetOrdinal("endDate")),
                        IsPercentage = reader.GetBoolean(reader.GetOrdinal("IsPercentage")),
                        DiscountAmount = reader.IsDBNull(reader.GetOrdinal("DiscountAmount"))? 0 : Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("DiscountAmount")))
                };
              }
            }
          }
        }
        throw new InvalidOperationException($"No sale found with ID {saleId}.");
      }

        // Get all sales
      public List<Sale> GetAllSales()
      {
        List<Sale> sales = new List<Sale>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
          connection.Open();

          string query = "SELECT * FROM Sale";
          using (SqlCommand cmd = new SqlCommand(query, connection))
          {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                sales.Add(new Sale
                    {
                        SaleID = reader.GetInt32(reader.GetOrdinal("SaleID")),
                        startDate = reader.GetDateTime(reader.GetOrdinal("startDate")),
                        endDate = reader.GetDateTime(reader.GetOrdinal("endDate")),
                        IsPercentage = reader.GetBoolean(reader.GetOrdinal("IsPercentage")),
                        DiscountAmount = reader.IsDBNull(reader.GetOrdinal("DiscountAmount"))? 0 : Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("DiscountAmount")))
                    });
              }
            }
          }
        }
        return sales;
      }

        // Add a new sale
      public bool AddSale(Sale sale)
      {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
          connection.Open();

          string query = "INSERT INTO Sale (startDate, endDate, IsPercentage, DiscountAmount) VALUES (@startDate, @endDate, @IsPercentage, @DiscountAmount)";
          using (SqlCommand cmd = new SqlCommand(query, connection))
          {
            cmd.Parameters.AddWithValue("@startDate", sale.startDate);
            cmd.Parameters.AddWithValue("@endDate", sale.endDate);
            cmd.Parameters.AddWithValue("@IsPercentage", sale.IsPercentage);
            cmd.Parameters.AddWithValue("@DiscountAmount", sale.DiscountAmount);

            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
          }
        }
      }

      // Update an existing sale
      public bool UpdateSale(Sale sale)
      {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
          connection.Open();

          string query = "UPDATE Sale SET startDate = @startDate, endDate = @endDate, IsPercentage = @IsPercentage, DiscountAmount = @DiscountAmount WHERE SaleID = @SaleID";
          using (SqlCommand cmd = new SqlCommand(query, connection))
          {
              cmd.Parameters.AddWithValue("@SaleID", sale.SaleID);
              cmd.Parameters.AddWithValue("@startDate", sale.startDate);
              cmd.Parameters.AddWithValue("@endDate", sale.endDate);
              cmd.Parameters.AddWithValue("@IsPercentage", sale.IsPercentage);
              cmd.Parameters.AddWithValue("@DiscountAmount", sale.DiscountAmount);

              int rowsAffected = cmd.ExecuteNonQuery();
              return rowsAffected > 0;
          }
        }
      }
    }
}
