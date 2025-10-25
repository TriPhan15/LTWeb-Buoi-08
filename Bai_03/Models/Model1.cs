using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTWeb08_Tuan08.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLTT_Model")
        {
        }

        public virtual DbSet<theloaitin> theloaitins { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        internal void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
