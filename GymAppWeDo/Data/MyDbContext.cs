using Microsoft.EntityFrameworkCore;

namespace GymAppWeDo.Data;

public class MyDbContext(IConfiguration configuration) : DbContext
{
    protected readonly IConfiguration Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("DatabaseParameters"));
    }
    
    public DbSet<Test.Test> Tests { get; set; }
}