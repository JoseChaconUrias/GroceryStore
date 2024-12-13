namespace User
{
    public interface IUserAccessor
    {
        public User GetUserById(int userId);
        public User GetUserByUsername(string username);
        bool CreateUser(User user);
        bool UpdateUser(int id, User user);
        bool DeleteUser(int id);
    }
}