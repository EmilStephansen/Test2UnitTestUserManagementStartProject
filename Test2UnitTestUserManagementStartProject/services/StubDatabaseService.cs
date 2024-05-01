using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    public class StubDatabaseService : IDatabaseService
    {    
        public void SaveUser(User user)
        {
            // Do nothing for stub
        }
        public User GetUserById(int id)
        {
            return new User { Id = 1, Name = "Charlie" };
        }
        public List<User> GetAllUsers()
        {
            return new List<User> { new User { Id = 1, Name = "Charlie" }, new User { Id = 2, Name = "Bobo" } };
        }
    }

}
