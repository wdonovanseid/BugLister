using Microsoft.EntityFrameworkCore;

namespace BugLister.Models
{
  public class BugListerContext : DbContext
  {
    public virtual DbSet<Language> Languages { get; set; }
    public DbSet<Issue> Issues { get; set; }
    // public DbSet<Link> Links { get; set; }
    // public DbSet<Project> Projects { get; set; }
    public BugListerContext(DbContextOptions options) : base(options) { }
  }
}