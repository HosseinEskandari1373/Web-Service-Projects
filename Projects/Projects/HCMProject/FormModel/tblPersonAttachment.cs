namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPersonAttachment")]
    public partial class tblPersonAttachment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte[] Attachment { get; set; }


        [Required]
        [StringLength(50)]
        public string FileType { get; set; }

        [Required]
        [StringLength(250)]
        public string FileName { get; set; }

        public virtual tblPerson tblPerson { get; set; }

    }
}
