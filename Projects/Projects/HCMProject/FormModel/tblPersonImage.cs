using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormModel
{
    [Table("tblPersonImage")]
    public partial class tblPersonImage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte[] Image { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string FileType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string FileName { get; set; }

        public virtual tblPerson tblPerson { get; set; }
    }
}
