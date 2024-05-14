namespace Khacaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts : IComparable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accounts()
        {
            StudentsAndAchievements = new HashSet<StudentsAndAchievements>();
            StudentsAndAwards = new HashSet<StudentsAndAwards>();
        }

        public int id { get; set; }

        public int idStudent { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? points { get; set; }
        public int myPosition = 0;
        public int balance = 0;
        public List<Accounts> lst = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsAndAchievements> StudentsAndAchievements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsAndAwards> StudentsAndAwards { get; set; }

        public virtual Students Students { get; set; }

        public int CompareTo(object obj)
        {
            if ((obj == null) || (!(obj is Accounts)))
            {
                return 0;
            }
            else
            {
                return points > ((Accounts)obj).points ? -1 : 1;
            }
        }
    }
}
