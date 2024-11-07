using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private DbContext _dbContext;
        public UserController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "User")]
        [Route("{userName}")]
        public IActionResult Get(string userName)
        {
            try
            {

                var users = _dbContext.Users.Where(x => x.userName == userName);
                if (users.Any())
                {
                    return Ok("Hello," + users.First().Name);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("User not found.");
            }
            return BadRequest("User not found.");
        }
    }
}
