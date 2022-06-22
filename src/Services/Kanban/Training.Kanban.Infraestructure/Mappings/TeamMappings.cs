using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Infraestructure.Mappings
{
    public class TeamMappings : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("team");

            builder.Property(t => t.Name)
                .HasColumnType("VARCHAR(45)")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("VARCHAR(255)");

            builder.HasOne(t => t.Leader)
                .WithMany()
                .HasForeignKey(t => t.LeaderId)
                .HasConstraintName("Fk_Team_User");

            builder.HasMany(b => b.Users)
                .WithMany(u => u.Teams)
                .UsingEntity<Dictionary<string, object>>("m2m_team_users",
                    b => b.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    b => b.HasOne<Team>().WithMany().HasForeignKey("TeamId"));
        }
    }
}
