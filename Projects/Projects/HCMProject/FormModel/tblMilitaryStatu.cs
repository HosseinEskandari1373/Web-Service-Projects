namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMilitaryStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMilitaryStatu()
        {
            tblPersons = new HashSet<tblPerson>();
        }

        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string EnName { get; set; }

        [Required]
        [StringLength(50)]
        public string FaName { get; set; }

        public byte OrderIndex { get; set; }

        public int HCMId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPerson> tblPersons { get; set; }

        public override string ToString()
        {
            return FaName;
        }
    }
}
