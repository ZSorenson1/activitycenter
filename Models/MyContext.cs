using Microsoft.EntityFrameworkCore;
namespace activitycenter.Models
{ 
    
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<AnActivity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities {get; set; }
    }
}