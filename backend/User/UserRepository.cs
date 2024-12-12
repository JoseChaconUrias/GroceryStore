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

                string query = "SELECT * FROM Users WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.read())
                        {
                            return new User
                            {
                                id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                username = reader.IsDBNull(reader.GetOrdinal("Username")) ? string.Empty : reader.GetString(reader.GetOrdinal("Username")),
                                password = reader.IsDBNull(reader.GetOrdinal("PasswordHash")) ? string.Empty : reader.GetString(reader.GetOrdinal("PasswordHash")),
                                phoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                            }
                        }
                    }
                }
            }
            throw new InvalidOperationException($"No user found with ID {id}.");
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

                var query = @"INSERT INTO Users (Username, PasswordHash, Email, PhoneNumber) 
                          VALUES (@Username, @PasswordHash @Email, PhoneNumber);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.password);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.phoneNumber);
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
                var query = @"UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email, PhoneNumber = @PhoneNumber
                          WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.password);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.phoneNumber);
                    cmd.Parameters.AddWithValue("@UserId", id);
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
                var query = "DELETE FROM Users WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@UserId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }
    }
}