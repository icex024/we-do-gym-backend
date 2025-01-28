using GymAppWeDo.User;
using GymAppWeDo.User.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymAppWeDo.Data;

public class MyDbContext: IdentityDbContext<User.Model.User>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        // options.UseNpgsql(Configuration.GetConnectionString("DatabaseParameters"));
    }
    
    public DbSet<Test.Test> Tests { get; set; }
    public DbSet<TokenInfo> TokenInfos { get; set; }
}