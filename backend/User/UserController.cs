namespace User
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public User GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                Console.WriteLine("Unable to Get User with id.");
            }
            return user;
        }

        [HttpGet("{username}")]
        public User GetUserByUsername(string username)
        {
            User user = await _userRepository.GetUserByUsername(id);
            if (user == null)
            {
                Console.WriteLine("Unable to get User with username.");
            }
            return user;
        }

        [HttpPost]
        public void CreateUser(User user)
        {
            int userId = await _userRepository.CreateUser(user);
            return;
        }

        [HttpPut("{userId}")]
        public void UpdateUser(int id, User user)
        {
            bool success = await _userRepository.UpdateUser(id, user);
            if (!success)
            {
                Console.WriteLine("Unable to Update User.");
            }
            return;
        }

        [HttpDelete("{userId}")]
        public void DeleteUser(int id)
        {
            bool success = await _userRepository.DeleteUser(id);
            if (!success)
            {
                Console.WriteLine("Unable to Delete User.");
            }
            return;
        }
    }
}