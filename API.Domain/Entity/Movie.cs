using API.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entity
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PremiereYear { get; set; }

        public List<MovieActor> MovieActor { get; set; } = new List<MovieActor>();
        public List<MovieGenre> MovieGenre { get; set; } = new List<MovieGenre>();
    }
}
