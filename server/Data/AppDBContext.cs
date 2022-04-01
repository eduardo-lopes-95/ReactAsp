using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    internal sealed class AppDBContext : DbContext
    {
        //create a table post
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var postToSeed = new Post[6];

            for (int i = 1; i <= postToSeed.Length; i++)
            {
                postToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is post {i} and it has some very interesting content. I have also liked the video and subscribed."
                };

            }

            modelBuilder.Entity<Post>().HasData(postToSeed);
        }
    }
}