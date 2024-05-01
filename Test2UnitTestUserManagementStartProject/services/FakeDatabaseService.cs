using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    // Fake implementation of IDatabaseService
    public class FakeDatabaseService : IDatabaseService
    {
        private readonly List<User> users = new List<User>();

        public void SaveUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return users.ToList();
        }
    }
}
