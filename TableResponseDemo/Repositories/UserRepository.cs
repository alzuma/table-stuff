using ServiceLocator;
using TableResponseDemo.Models;

namespace TableResponseDemo.Repositories;

[Service(ServiceLifetime.Singleton)]
public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new() { Name = "John" },
        new() { Name = "Jane" },
        new() { Name = "Jack" },
        new() { Name = "Jill" }
    };

    public IEnumerable<User> GetUsers()
    {
        return _users;
    }

    public User GetUser(string name)
    {
        var user = _users.FirstOrDefault(u => u.Name == name);
        if (user == null)
        {
            throw new Exception($"User {name} not found");
        }

        return user;
    }
}