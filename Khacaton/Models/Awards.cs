namespace Khacaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Khacaton.Services;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Awards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Awards()
        {
            StudentsAndAwards = new HashSet<StudentsAndAwards>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public int? cost { get; set; }
        public List<Awards> lstAwards = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsAndAwards> StudentsAndAwards { get; set; }
    }
}
