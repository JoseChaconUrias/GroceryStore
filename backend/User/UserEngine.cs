namespace User
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserAccessor _userAccessor;

        public UserEngine(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        public User GetUserById(int userId)
        {
            var tempuser = _userAccessor.GetUserById(userId);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with ID {userId}");
            }
            return tempuser;
        }

        public User GetUserByUsername(string username)
        {
            var tempuser = _userAccessor.GetUserByUsername(username);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with username {username}");
            }
            return tempuser;
        }

        public bool CreateUser(User user)
        {
            return _userAccessor.CreateUser(user);
        }

        public bool UpdateUser(int id, User user)
        {
            var tempuser = _userAccessor.GetUserById(id);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with ID {id}");
            }
            return _userAccessor.UpdateUser(id, user);
        }

        public bool DeleteUser(int id)
        {
            var tempuser = _userAccessor.GetUserById(id);
            if (tempuser == null)
            {
                throw new ArgumentException($"No user found with ID {id}");
            }
            return _userAccessor.DeleteUser(id);
        }
    }
}