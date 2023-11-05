namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEducationDegree")]
    public partial class tblEducationDegree
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEducationDegree()
        {
            tblEducationInfoes = new HashSet<tblEducationInfo>();
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
        public virtual ICollection<tblEducationInfo> tblEducationInfoes { get; set; }

        public override string ToString()
        {
            return FaName;
        }
    }
}
