using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace Users
{
    // I'm aware that implementing the DAL is incorrect. Doing so because creating
    // a thin DAL to this entity seems to be redundant and duck typing doesn't exist in the type system.
    internal class UsersDB : IUsersDBDAL
    {
        public IEnumerable<User> Users { get; set; }
        public UsersDB(IEnumerable<User> users)
        {
            this.Users = users;
        }
        public Task<bool> DoesExist(string userName)
        {
            return Task.Run<bool>(() =>
            {
                // "Normal" loops are faster than LINQ. Sometimes readability should also be considered where I assume that LINQ is better.
                foreach (var user in this.Users)
                {
                    if (user.Name == userName)
                    {
                        return true;
                    }
                }
                return false;
            });
        }
    }
}