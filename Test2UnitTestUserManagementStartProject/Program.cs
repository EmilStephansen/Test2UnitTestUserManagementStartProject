using Test2UnitTestUserManagementStartProject.services;

IDatabaseService database = new SqliteDatabaseService("DataSource=database.db");

UserManager userManager = new UserManager(database);

userManager.AddUser("Pjerrots ven");
Console.WriteLine("listing all users:");
foreach (var user in userManager.GetAllUsers())
{
    Console.WriteLine($"{user.Name} with id: {user.Id}");
}