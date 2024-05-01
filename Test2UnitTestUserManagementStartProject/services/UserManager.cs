using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    public class UserManager
    {
        private IDatabaseService dbStorage;

        public UserManager(IDatabaseService userRepository)
        {
            this.dbStorage = userRepository;
        }

        public void AddUser(string name)
        {
            User user = new User { Name = name };
            dbStorage.SaveUser(user);
        }

        public User GetUserById(int id)
        {
            return dbStorage.GetUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dbStorage.GetAllUsers();
        }
    }
}
