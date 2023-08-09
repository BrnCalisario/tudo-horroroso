namespace TudoHorroroso.Repositories;
using Model;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsValid(User user);
    Task<User> FindByName(string name);
    Task<User> FindByEmail(string email);
}