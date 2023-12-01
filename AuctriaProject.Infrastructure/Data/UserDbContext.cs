using AuctriaProject.Domain.Entities;
using AuctriaProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctriaProject.Infrastructure.Data
{
    public class UserDbContext : DbContext
    {
        private readonly ISharedContext _sharedContext;
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

