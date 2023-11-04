namespace SQLiteDbAccess.Services.User;

public interface IUserService
{
    /// <summary>
    /// Get User.
    /// </summary>
    /// <param name="userID">The user id.</param>
    /// <returns>User</returns>
    Task<Data.Models.User?> GetUserAsync(int userID);

    /// <summary>
    /// Get Users.
    /// </summary>
    /// <returns>List of Users</returns>
    Task<List<Data.Models.User>> GetUsersAsync();

    /// <summary>
    /// Update User.
    /// </summary>
    /// <param name="user">The User.</param>
    /// <returns>Task</returns>
    Task UpdateUserAsync(Data.Models.User user);

    /// <summary>
    /// Create User.
    /// </summary>
    /// <param name="user">The User.</param>
    /// <returns>User</returns>
    Task<Data.Models.User> CreateUserAsync(Data.Models.User user);

    /// <summary>
    /// Delete User.
    /// </summary>
    /// <param name="user">The User.</param>
    /// <returns>Task</returns>
    Task DeleteUserAsync(int userId);
}