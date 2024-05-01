using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2UnitTestUserManagementStartProject.services;

namespace Test2StartUpTestProject
{
    [TestClass]
    public class SqlitteDataBaseTests
    {
        IDatabaseService sqlDataBase;
        [TestInitialize]
        public void Setup()
        {
            sqlDataBase = new SqliteDatabaseService("DataSource=myshareddb;mode=memory;cache=shared");
        }
        [TestMethod]
        public void SqlLiteDatabaseHasInitialData()
        {
            //create in memory database!
            //IDatabaseService sqlDataBase = new SqliteDatabaseService("DataSource=myshareddb;mode=memory;cache=shared");
            var expected = "Pjerrot";
            var actual = sqlDataBase.GetUserById(1).Name;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SqlLiteDataBaseCanAddAndGetUser()
        {
            sqlDataBase.SaveUser(new User { Name = "newGuy" });

            var expected = "newGuy";
            var actual = sqlDataBase.GetUserById(3).Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanGetAllUsersFromInitialData()
        {
            var expected = new List<string> { "Pjerrot", "dee" };
            var actual = sqlDataBase.GetAllUsers().Select(x=>x.Name).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
