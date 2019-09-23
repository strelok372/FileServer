using Microsoft.EntityFrameworkCore;

public class DBC : DbContext
{
    public DbSet<ModEntity> Mods { get; set; }
    public DbSet<MapEntity> Maps { get; set; }

    public DBC(DbContextOptions<DBC> dbContext) : base(dbContext)
    {
        Database.EnsureCreated();
    }

}