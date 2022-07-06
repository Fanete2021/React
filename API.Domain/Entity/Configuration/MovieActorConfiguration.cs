using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Entity.Configuration
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(m => new { m.MovieId, m.ActorId });

            builder.HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActor)
                .HasForeignKey(ma => ma.MovieId);

            builder.HasOne(am => am.Actor)
                .WithMany(a => a.MovieActor)
                .HasForeignKey(am => am.ActorId);
        }
    }
}
