using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request {
    public class MovieCreateRequestModel {

        public string Title { get; set; }

        public string Overview { get; set; }

        public decimal? Budget { get; set; } //store null if value isn't provided

        public decimal? Revenue { get; set; } //store null if value isn't provided
    }
}
