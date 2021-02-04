using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasKey(blog => blog.Id);

            modelBuilder.Entity<Author>()
                .HasKey(author => author.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(comment => comment.Id);

            modelBuilder.Entity<Tag>()
                .HasKey(tag => tag.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
    }
}
