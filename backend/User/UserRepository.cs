namespace User {
    using System.Data.SqlClient;

    public class UserRepository : IUserRepository
    {
        private string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users WHERE userID = @userID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.read())
                        {
                            return new User
                            {
                                id = reader.GetInt32(reader.GetOrdinal("userID")),
                                username = reader.IsDBNull(reader.GetOrdinal("username")) ? string.Empty : reader.GetString(reader.GetOrdinal("username")),
                                password = reader.IsDBNull(reader.GetOrdinal("password")) ? string.Empty : reader.GetString(reader.GetOrdinal("password")),
                                phoneNumber = reader.IsDBNull(reader.GetOrdinal("phoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("phoneNumber")),
                                email = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : reader.GetString(reader.GetOrdinal("email")),
                                firstName = reader.IsDBNull(reader.GetOrdinal("firstName")) ? string.Empty : reader.GetString(reader.GetOrdinal("firstName")),
                                lastName = reader.IsDBNull(reader.GetOrdinal("lastName")) ? string.Empty : reader.GetString(reader.GetOrdinal("lastName")),
                                address = reader.IsDBNull(reader.GetOrdinal("address")) ? string.Empty : reader.GetString(reader.GetOrdinal("address"))
                            }
                        }
                    }
                }
            }
            throw new InvalidOperationException($"No user found with ID {id}.");
        }

        public User GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.read())
                        {
                            return new User
                            {
                                id = reader.GetInt32(reader.GetOrdinal("userID")),
                                username = reader.IsDBNull(reader.GetOrdinal("username")) ? string.Empty : reader.GetString(reader.GetOrdinal("username")),
                                password = reader.IsDBNull(reader.GetOrdinal("password")) ? string.Empty : reader.GetString(reader.GetOrdinal("password")),
                                phoneNumber = reader.IsDBNull(reader.GetOrdinal("phoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("phoneNumber")),
                                email = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : reader.GetString(reader.GetOrdinal("email")),
                                firstName = reader.IsDBNull(reader.GetOrdinal("firstName")) ? string.Empty : reader.GetString(reader.GetOrdinal("firstName")),
                                lastName = reader.IsDBNull(reader.GetOrdinal("lastName")) ? string.Empty : reader.GetString(reader.GetOrdinal("lastName")),
                                address = reader.IsDBNull(reader.GetOrdinal("address")) ? string.Empty : reader.GetString(reader.GetOrdinal("address"))
                            }
                        }
                    }
                }
            }
            throw new InvalidOperationException($"No user found with username {username}.");
        }

        public bool CreateUser(User user)
        {
            User check = GetUserById(user.id);
            if (check != null)
            {
                throw new InvalidOperationException($"User already exists with ID {user.id}.");
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var query = @"INSERT INTO Users (username, password, email, phoneNumber, firstName, lastName, address) 
                          VALUES (@username, @password, @email, @phoneNumber, @firstName, @lastName, @address);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                    cmd.Parameters.AddWithValue("@firstName", user.firstName);
                    cmd.Parameters.AddWithValue("@lastName", user.lastName);
                    cmd.Parameters.AddWithValue("@address", user.address);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateUser(int id, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"UPDATE Users SET username = @username, password = @password, email = @email, phoneNumber = @phoneNumber, firstName = @firstName, lastName = @lastName, address = @address
                          WHERE userID = @userID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                    cmd.Parameters.AddWithValue("@firstName", user.firstName);
                    cmd.Parameters.AddWithValue("@lastName", user.lastName);
                    cmd.Parameters.AddWithValue("@address", user.address);
                    cmd.Parameters.AddWithValue("@userID", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Users WHERE userID = @userID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@userID", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }
    }
}