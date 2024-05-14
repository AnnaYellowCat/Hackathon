namespace Khacaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentsAndAchievements
    {
        public int id { get; set; }

        public int idAccount { get; set; }

        public int idAchievement { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateReceipt { get; set; }

        public bool? receipt { get; set; }

        public virtual Accounts Accounts { get; set; }

        public virtual Achievements Achievements { get; set; }
    }
}
