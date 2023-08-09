using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TudoHorroroso.Repositories;
using Model;

public class UserRepository : IUserRepository
{
    private readonly TudoHorrorosoContext ctx;

    public UserRepository(TudoHorrorosoContext ctx)
        => this.ctx = ctx;

    public async Task Add(User obj)
    {
        await ctx.Users.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(User obj)
    {
        ctx.Users.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(User obj)
    {   
        ctx.Users.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<User>> Filter(Expression<Func<User, bool>> exp)
    {
        var query = ctx.Users.Where(exp);
        return await query.ToListAsync();
    }

    public async Task<bool> IsValid(User user)
    {
        var query = await ctx.Users.AnyAsync(u => u.UserName == user.UserName || u.Email == user.Email);
        return !query;
    }

    public async Task<User> Find(int id)
    {
        User u = await ctx.Users.FindAsync(id);
        return u;
    }

    public async Task<User> FindByName(string name)
    {
        User u = await ctx.Users.FirstOrDefaultAsync(u => u.UserName == name);
        return u;
    }

    public async Task<User> FindByEmail(string email)
    {
        User u = await ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
        return u;
    }
}