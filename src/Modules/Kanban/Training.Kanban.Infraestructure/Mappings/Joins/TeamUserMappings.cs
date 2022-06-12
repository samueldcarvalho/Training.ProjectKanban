using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Kanban.Domain.Teams.Joins;

namespace Training.Kanban.Infraestructure.Mappings.Joins
{
    public class TeamUserMappings : IEntityTypeConfiguration<TeamUser>
    {
        public void Configure(EntityTypeBuilder<TeamUser> builder)
        {
            builder.HasKey(x => 
                new { x.UserId, x.TeamId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.TeamUsers)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.TeamUsers)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
