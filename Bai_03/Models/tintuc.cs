namespace LTWeb08_Tuan08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tintuc")]
    public partial class tintuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTin { get; set; }

        public int? IDLoai { get; set; }

        [StringLength(100)]
        public string Tieudetin { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidungtin { get; set; }

        public virtual theloaitin theloaitin { get; set; }
    }
}
