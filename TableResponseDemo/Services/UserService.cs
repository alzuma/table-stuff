using ServiceLocator;
using TableResponseDemo.Models;
using TableResponseDemo.Repositories;

namespace TableResponseDemo.Services;

[Service(ServiceLifetime.Singleton)]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public TableResponse<IEnumerable<User>> GetUsers(bool rowsOnly)
    {
        var users = _userRepository.GetUsers().ToArray();

        var tableResponse = new TableResponse<IEnumerable<User>>.Builder()
            .WithRows(users);

        if (!rowsOnly)
        {
            tableResponse.WithMeta(new Meta { Total = users.Length });
        }

        return tableResponse.BuildRows(rowsOnly);
    }

    public TableResponse<User> GetUser(string name, bool rowsOnly)
    {
        var user = _userRepository.GetUser(name);
        
        var tableResponse = new TableResponse<User>.Builder()
            .WithRows(user);

        if (!rowsOnly)
        {
            tableResponse.WithMeta(new Meta { Total = 1 });
        }

        return tableResponse.BuildRow(rowsOnly);
    }
}