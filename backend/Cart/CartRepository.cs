namespace Cart {
    using System;
    using Product;
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;

    public class CartRepository : ICartRepository
    {
        private string _connectionString;
        public CartRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get cart from database based on cartId
        public Cart getUserCart(string cartId)
        {
            Cart cart = new Cart;
            double tempPrice = 0;
            SortedDictionary<Product, int> tempItemList;
            using (SQLConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Query to select Cart by UserID
                string query = "SELECT * FROM Cart WHERE CartId = @CartId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.read())
                        {
                            cart.cartId = reader.GetInt32(reader.GetOrdinal("CartId"));
                            cart.userId = reader.GetInt32(reader.GetOrdinal("UserId"));
                            tempItemList.Add(reader.GetInt32(reader.GetOrdinal("ProductId")), reader.GetInt32(reader.GetOrdinal("Amount")));
                            tempPrice = tempPrice + reader.GetDouble(reader.GetOrdinal("Price"));
                        }
                        while (reader.Read())
                        {
                            tempItemList.Add(reader.GetInt32(reader.GetOrdinal("ProductId")), reader.GetInt32(reader.GetOrdinal("Amount")));
                            tempPrice = tempPrice + reader.GetDouble(reader.GetOrdinal("Price"));
                        }
                        cart.totalPrice = tempPrice;
                        cart.itemList = tempItemList;
                    }
                }
            }
            return cart;
        }

        // Add product to cart
        bool addToCart(int cartId, Product product, int amount)
        {
            Cart tempCart = getUserCart(cartId);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cart (CartId, UserId, ProductId, Amount, Price) VALUES(@CartId, @UserId, @ProductId, @Amount, @Price)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    cmd.Parameters.AddWithValue("@UserId", tempCart.userId);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Price", (product.Price * amount));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        // Remove product from cart
        bool removeFromCart(int cartId, Product product)
        {
            SortedDictionary<Product, int> tempList;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Cart WHERE CartId = @cartId AND ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        // Update amount of product in cart
        bool updateAmount(int cartId, Product product, int amount)
        {
            SortedDictionary<Product, int> tempList;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "Update Cart SET Amount = @Amount WHERE CartId = @CartId AND ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        // Create a new cart for a user with one product
        bool initiateCart(Cart cart)
        {
            if (cart.itemList.Count != 1)
            {
                throw new InvalidOperationException($"Cannot create new cart instance with more or less than one product.");
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Cart (UserId, ProductId, Amount Price) VALUES(@UserId, @ProductId, @Amount, @Price);";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", cart.userId);
                    cmd.Parameters.AddWithValue("@ProductId", cart.itemList.First().Key;
                    cmd.Parameters.AddWithValue("@ProductId", cart.itemList.First().Value;
                    cmd.Parameters.AddWithValue("@Price", cart.totalPrice);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        void clearCart(int cartId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Cart WHERE CartId = @CartId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }
    }
}