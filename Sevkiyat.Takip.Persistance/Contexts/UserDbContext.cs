using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.Contexts;

public class UserDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{

    public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("users");
    }

}
