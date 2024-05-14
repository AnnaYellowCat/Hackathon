namespace Khacaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentsAndAwards
    {
        public StudentsAndAwards() { }
        public StudentsAndAwards(int idAccount, int idAward, string promocode, bool? isActive)
        {
            this.idAccount = idAccount;
            this.idAward = idAward;
            this.promocode = promocode;
            this.isActive = isActive;
        }

        public int id { get; set; }

        public int idAccount { get; set; }

        public int idAward { get; set; }

        [StringLength(30)]
        public string promocode { get; set; }

        public bool? isActive { get; set; }

        public virtual Accounts Accounts { get; set; }

        public virtual Awards Awards { get; set; }
    }
}
