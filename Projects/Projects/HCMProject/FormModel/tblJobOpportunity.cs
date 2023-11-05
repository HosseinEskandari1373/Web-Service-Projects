namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblJobOpportunity")]
    public partial class tblJobOpportunity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblJobOpportunity()
        {
            tblPersons = new HashSet<tblPerson>();
        }

        public int Id { get; set; }

        public Guid HCMId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }

        [Required]
        [StringLength(8)]
        public string ExpireDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPerson> tblPersons { get; set; }
    }
}
