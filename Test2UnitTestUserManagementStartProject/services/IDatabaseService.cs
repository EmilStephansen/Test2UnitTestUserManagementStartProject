using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    public interface IDatabaseService
    {
        void SaveUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
    }
}
