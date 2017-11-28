using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw_8.Models
{
    public partial class Classifications
    {
        public int ID { get; set; }

        public int ArtWorkID { get; set; }

        public int GenreID { get; set; }

        public virtual ArtWork ArtWork{get; set;}

        public virtual Genre Genre { get; set; }
    }
}