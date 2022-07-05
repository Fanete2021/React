using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Domain.Entity
{
    public class Movie_Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Movie_actor_id { get; set; }
        public int Movie_id { get; set; }
        public int Actor_id { get; set; }

    }
}
