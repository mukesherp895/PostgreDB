using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreDB.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.DataAccess.DomainConfig
{
    public class DateMapConfig : IEntityTypeConfiguration<DateMaps>
    {
        public void Configure(EntityTypeBuilder<DateMaps> builder)
        {
            builder.Property(p => p.BsFiscalYear).IsRequired().HasColumnType("varchar(9)");
            builder.Property(p => p.BsYear).IsRequired().HasColumnType("varchar(4)");
            builder.Property(p => p.BsMonth).IsRequired().HasColumnType("varchar(2)");
            builder.Property(p => p.BsStartDate).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.BsEndDate).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.EngStartDate).IsRequired().HasColumnType("date");
            builder.Property(p => p.EngEndDate).IsRequired().HasColumnType("date");
        }
    }
}
