namespace User
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IUserRepository _userRepository;

        public UserAccessor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            var tempuser = _userRepository.GetUserById(id);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with ID {id}");
            }
            return _userRepository.UpdateUser(id, user); ;
        }

        public bool DeleteUser(int id)
        {
            var tempuser = _userRepository.GetUserById(id);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with ID {id}");
            }
            return _userRepository.DeleteUser(id); ;
        }
    }
}