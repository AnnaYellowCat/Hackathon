namespace Khacaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Achievements
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Achievements()
        {
            StudentsAndAchievements = new HashSet<StudentsAndAchievements>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public int? reward { get; set; }

        [StringLength(200)]
        public string image { get; set; }

        public List<Achievements> lstMy = null;
        public List<Achievements> lstDiff = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsAndAchievements> StudentsAndAchievements { get; set; }
    }
}
