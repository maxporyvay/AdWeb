using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(800);

            builder.Property(x => x.Login).HasMaxLength(800);

            builder.Property(x => x.Password).HasMaxLength(800);

            /*builder.HasMany(x => x.AdBoards)
                .WithOne(x => x.Ad)
                .HasForeignKey(x => x.AdId);*/
        }
    }
}
