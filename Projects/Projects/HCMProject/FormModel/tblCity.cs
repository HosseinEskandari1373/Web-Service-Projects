namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCity")]
    public partial class tblCity
    {
        [Key]
        [Column(Order = 0)]
        public byte ProvinceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual tblProvince tblProvince { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
