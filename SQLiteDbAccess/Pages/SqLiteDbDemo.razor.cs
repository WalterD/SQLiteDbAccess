using Microsoft.AspNetCore.Components;
using SQLiteDbAccess.Data.Models;
using SQLiteDbAccess.Services.User;
using System.Diagnostics;
using System.Text;

namespace SQLiteDbAccess.Pages;

public partial class SqLiteDbDemo
{
    [Inject] IUserService UserService { get; set; }

    bool isLoaded = false;
    int userID;
    User? user;
    List<User> users = new();
    StringBuilder sb = new();

    /// <summary>
    /// OnInitializedAsync
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        sb.AppendLine("SqLite Db Demo Log");
        await GetUsersAsync();
        isLoaded = true;
    }

    /// <summary>
    /// OnSubmitButtonClickAsync
    /// </summary>
    async Task OnUpdateUserClickAsync()
    {
        var stopwatch = Stopwatch.StartNew();
        if (user.UserID > 0)
        {
            await UserService.UpdateUserAsync(user);
        }
        else
        {
            await UserService.CreateUserAsync(user);
        }

        stopwatch.Stop();
        sb.AppendLine($"User updated @{DateTime.Now} in {stopwatch.ElapsedMilliseconds}ms");
        await GetUsersAsync();
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns>List of users.</returns>
    async Task GetUsersAsync()
    {
        var stopwatch = Stopwatch.StartNew();
        users = await UserService.GetUsersAsync();
        stopwatch.Stop();
        sb.AppendLine($"Users retrieved in {stopwatch.ElapsedMilliseconds}ms");
    }

    /// <summary>
    /// On edit Click.
    /// </summary>
    async Task OnEditClick(int userId)
    {
        var stopwatch = Stopwatch.StartNew();
        user = await UserService.GetUserAsync(userId);
        stopwatch.Stop();
        sb.AppendLine($"User retrieved @{DateTime.Now} in {stopwatch.ElapsedMilliseconds}ms");
    }

    /// <summary>
    /// On Delete Click.
    /// </summary>
    async Task OnDeleteClick(int userId)
    {
        var stopwatch = Stopwatch.StartNew();
        await UserService.DeleteUserAsync(userId);
        stopwatch.Stop();
        sb.AppendLine($"User deleted @{DateTime.Now} in {stopwatch.ElapsedMilliseconds}ms");
        NewUserClick();
        await GetUsersAsync();
    }

    /// <summary>
    /// On New User Click.
    /// </summary>
    void NewUserClick()
    {
        user = new();
    }
}
