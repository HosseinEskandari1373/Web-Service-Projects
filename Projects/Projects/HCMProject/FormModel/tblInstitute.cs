namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblInstitute")]
    public partial class tblInstitute
    {
        public int? Id { get; set; }

        public int? InstituteTypeId { get; set; }

        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
