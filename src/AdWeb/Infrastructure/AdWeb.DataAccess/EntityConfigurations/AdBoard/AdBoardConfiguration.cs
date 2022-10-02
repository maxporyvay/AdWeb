using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.AdBoard
{
    public class AdBoardConfiguration : IEntityTypeConfiguration<Domain.AdBoard>
    {
        public void Configure(EntityTypeBuilder<Domain.AdBoard> builder)
        {
            builder.ToTable("AdBoards");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
