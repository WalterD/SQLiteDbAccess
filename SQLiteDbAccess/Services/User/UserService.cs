using Microsoft.EntityFrameworkCore;
using SQLiteDbAccess.Data;

namespace SQLiteDbAccess.Services.User;

/// <summary>
/// Class UserService.
/// </summary>
public class UserService : IUserService
{
    private readonly IDbContextFactory<MySQLiteDbContext> mySQLiteDbContextFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="mySQLiteDbContextFactory">Db Context Factory.</param>
    public UserService(IDbContextFactory<MySQLiteDbContext> mySQLiteDbContextFactory)
    {
        this.mySQLiteDbContextFactory = mySQLiteDbContextFactory;
    }

    /// <inheritdoc/>
    public async Task<Data.Models.User?> GetUserAsync(int userID)
    {
        using var db = mySQLiteDbContextFactory.CreateDbContext();
        var user = await db.Users
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.UserID == userID);
        return user;
    }

    /// <inheritdoc/>
    public async Task<List<Data.Models.User>> GetUsersAsync()
    {
        using var db = mySQLiteDbContextFactory.CreateDbContext();
        var users = await db.Users
                            .AsNoTracking()
                            .ToListAsync();
        return users;
    }

    /// <inheritdoc/>
    public async Task UpdateUserAsync(Data.Models.User user)
    {
        using var db = mySQLiteDbContextFactory.CreateDbContext();
        db.Users.Update(user);
        await db.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<Data.Models.User> CreateUserAsync(Data.Models.User user)
    {
        using var db = mySQLiteDbContextFactory.CreateDbContext();
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return user;
    }

    /// <inheritdoc/>
    public async Task DeleteUserAsync(int userId)
    {
        var user = new Data.Models.User() { UserID = userId };
        using var db = mySQLiteDbContextFactory.CreateDbContext();
        db.Users.Remove(user);
        await db.SaveChangesAsync();
    }
}