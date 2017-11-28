using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hw_8.Models
{
    public partial class ArtWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArtWork()
        {
            //bring in classifications hashset for relationship
            Classifications = new HashSet<Classifications>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Art Piece")]
        public string Title { get; set; }

        public int ArtistID { get; set; }

        public virtual Artist Artist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classifications> Classifications { get; set; }
    }
}