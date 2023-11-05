namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblWorkInfo")]
    public partial class tblWorkInfo
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Post { get; set; }

        [Required]
        [StringLength(500)]
        public string Duties { get; set; }

        [Required]
        [StringLength(8)]
        public string StartDate { get; set; }

        [Required]
        [StringLength(8)]
        public string EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LeaveReason { get; set; }

        public int LastSalary { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        public virtual tblPerson tblPerson { get; set; }

        public override string ToString()
        {
            return $"{CompanyName } - {StartDate} -> {EndDate}";
        }
    }
}
