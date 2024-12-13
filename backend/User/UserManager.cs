namespace User
{
    public class UserManager : IUserManager
    {
        private readonly IUserEngine _userEngine;

        public UserAccessor(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public bool UpdateUser(int id, User user)
        {
            return _userRepository.UpdateUser(id, user); ;
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id); ;
        }
    }
}