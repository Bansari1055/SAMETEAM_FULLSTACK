using Microsoft.EntityFrameworkCore;
using SameTeamAPI.Models;

namespace SameTeamAPI.Data
{
    public class SameTeamDbContext : DbContext
    {
        public SameTeamDbContext(DbContextOptions<SameTeamDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Chore> Chores { get; set; }
    }
}
