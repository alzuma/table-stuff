using TableResponseDemo.Models;
using TableResponseDemo.Controllers;

namespace TableResponseDemo.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUser(string name);
}