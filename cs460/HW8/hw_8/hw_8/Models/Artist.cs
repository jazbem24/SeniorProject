using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace hw_8.Models
{

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            //bring in ArtWork hashset for relationship
            ArtWork = new HashSet<ArtWork>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWork {get; set;}


    }
}