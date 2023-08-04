namespace TudoHorroroso.Repositories;
using Model;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsValid(User user);
}