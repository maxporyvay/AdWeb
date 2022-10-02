using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.Ad
{
    public class AdConfiguration : IEntityTypeConfiguration<Domain.Ad>
    {
        public void Configure(EntityTypeBuilder<Domain.Ad> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.AdTitle).HasMaxLength(800);

            builder.Property(x => x.AdDescription).HasMaxLength(2000);

            builder.HasMany(x => x.AdBoards)
                .WithOne(x => x.Ad)
                .HasForeignKey(x => x.AdId);
        }
    }
}
