namespace hw_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SearchLog")]
    public partial class SearchLog
    {
        public int ID { get; set; }

        public DateTime SearchDate { get; set; }

        [Required]
        public string SearchRequest { get; set; }

        [Required]
        public string Agent { get; set; }

        [StringLength(128)]
        public string IPAddress { get; set; }
    }
}
