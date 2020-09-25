using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public IUsersDBDAL UsersDBDAL { get; set; }
        public UsersController(
            IUsersDBDAL usersDBDAL
        )
        {
            this.UsersDBDAL = usersDBDAL;
        }


        [HttpGet("DoesExist/{userName}")]
        public async Task<bool> DoesExist(string userName)
        {
            return await this.UsersDBDAL.DoesExist(userName);
        }
    }
}
