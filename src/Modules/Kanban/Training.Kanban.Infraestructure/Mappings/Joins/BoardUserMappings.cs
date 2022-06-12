using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Kanban.Domain.Boards.Joins;

namespace Training.Kanban.Infraestructure.Mappings.Joins
{
    public class BoardUserMappings : IEntityTypeConfiguration<BoardUser>
    {
        public void Configure(EntityTypeBuilder<BoardUser> builder)
        {
            builder.HasKey(x => 
                new { x.BoardId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.BoardUsers)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Board)
                .WithMany(x => x.BoardUsers)
                .HasForeignKey(x => x.BoardId);

        }
    }
}
