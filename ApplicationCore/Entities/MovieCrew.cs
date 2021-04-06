using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities {

    [Table("MovieCrew")]
    public class MovieCrew {
        public int MovieId { get; set; }
        public int CrewId { get; set; }
        public string Department{ get; set; }
        public string Job { get; set; }

        public Movie Movies { get; set; }
        public Crew Crews { get; set; }

    }
}
