using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:dapper-test.database.windows.net,1433;Initial Catalog=BlogContext;Persist Security Info=False;User ID=visschers.m;Password=HwGesY6nMCFjpnaVbcjNfSu5JVi24a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }

            base.OnConfiguring(optionsBuilder);
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
