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
        public User GetUser(int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                Console.WriteLine("Unable to Create User.");
            }
            return user;
        }

        [HttpPost]
        public void CreateUser(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);
            int userId = await _userRepository.CreateUser(user);
            return;
        }

        [HttpPut("{userId}")]
        public void UpdateUser(int id, User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);
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

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}