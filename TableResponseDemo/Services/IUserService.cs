using TableResponseDemo.Models;

namespace TableResponseDemo.Services;

public interface IUserService
{
    TableResponse<IEnumerable<User>> GetUsers(bool rowsOnly);
    TableResponse<User> GetUser(string name, bool rowsOnly);
}