using Microsoft.EntityFrameworkCore;
using SQLiteDbAccess.Data.Models;

namespace SQLiteDbAccess.Data;

public class MySQLiteDbContext : DbContext
{
    public MySQLiteDbContext(DbContextOptions<MySQLiteDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
