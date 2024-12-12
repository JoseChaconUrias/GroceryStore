namespace User
{
    public interface IUserRepository
    {
        public User GetUserById(int userId);
        bool CreateUser(User user);
        bool UpdateUser(int id, User user);
        bool DeleteUser(int id);
    }
}