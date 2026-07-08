using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2UnitTestUserManagementStartProject.services;

namespace Test2StartUpTestProject
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void UserManager_WithFakeDatabaseService_CanAddUserAndGetUserById()
        {
            // Arrange
            var fakeDatabase = new FakeDatabaseService();
            var userManager = new UserManager(fakeDatabase);

            // Act
            userManager.AddUser("Alice");
            userManager.AddUser("Bob");
            var retrievedUser = userManager.GetUserById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual("Alice", retrievedUser.Name);
        }
        [TestMethod]
        public void UserManager_WithFakeDatabaseService_CanAddUserAndGetAll()
        {
            // Arrange
            var fakeDatabase = new FakeDatabaseService();
            var userManager = new UserManager(fakeDatabase);

            // Act
            userManager.AddUser("Alice");
            userManager.AddUser("Bob");

            // Assert
            CollectionAssert.AreEquivalent(new[] { "Alice", "Bob" }, userManager.GetAllUsers().Select(x => x.Name).ToArray());
        }
        [TestMethod]
        public void UserManager_WithStubDatabaseService_ReturnsStubbedData()
        {
            // Arrange
            var stubDatabase = new StubDatabaseService();
            var userManager = new UserManager(stubDatabase);

            // Act
            var retrievedUser = userManager.GetUserById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual("Charlie", retrievedUser.Name);
        }
        [TestMethod]
        public void UserManager_WithStubDatabaseService_ReturnsStubbedCollectionOfData()
        {
            // Arrange
            var stubDatabase = new StubDatabaseService();
            var userManager = new UserManager(stubDatabase);
            var expected = new List<User> { new User { Id = 1, Name = "Charlie" }, new User { Id = 2, Name = "Bobo" } };
            var actual = userManager.GetAllUsers().ToList();
            // Assert
            CollectionAssert.AreEqual( expected.Select(x=>x.Name).ToList(), actual.Select(x=>x.Name).ToList());
        }
        [TestMethod]
        public void UserManager_WithMockDatabaseService_ReturnsMockedData()
        {
            // Arrange
            var mockDatabase = Substitute.For<IDatabaseService>();
            mockDatabase.GetUserById(1).Returns(new User { Id = 1, Name = "Dee" });
            var userManager = new UserManager(mockDatabase);
            // Act
            var retrievedUser = userManager.GetUserById(1);
            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual("Dee", retrievedUser.Name);
        }


        [TestMethod]
        public void UserManager_WithMockDatabaseService_ReturnsMockedListData()
        {
            // Arrange
            var mockDatabase = Substitute.For<IDatabaseService>();
            var expected = new List<User> { new User { Id = 1, Name = "Charlie" }, new User { Id = 2, Name = "Bobo" } };
            mockDatabase.GetAllUsers().Returns(expected);
            var userManager = new UserManager(mockDatabase);
            // Act
            var actual = userManager.GetAllUsers();
            // Assert
            CollectionAssert.AreEqual( expected.Select(x => x.Name).ToList(), actual.Select(x => x.Name).ToList());
        }
    }
}
