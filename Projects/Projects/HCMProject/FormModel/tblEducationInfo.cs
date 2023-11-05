namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tblEducationInfo")]
    public partial class tblEducationInfo
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public byte EducationDegreeId { get; set; }

        public tblEducationDegree EducationDegree
        {
            get
            {
                return Common.frmDb.tblEducationDegrees.Where(x => x.Id == EducationDegreeId).FirstOrDefault();
            }
        }

        public string Field { get; set; }

        [StringLength(50)]
        public string SubField { get; set; }

        public byte? InstituteTypeId { get; set; }

        public tblInstituteType InstituteType
        {
            get;
            //{
                //return Common.frmDb.tblInstituteTypes.Where(x => x.Id == InstituteTypeId).FirstOrDefault();
            //}
        }
        [Required]
        [StringLength(50)]
        public string Institute { get; set; }

        public short? EndYear { get; set; }

        public float? GPA { get; set; }

        [Required]
        public bool IsFinished { get; set; }

        public virtual tblEducationDegree tblEducationDegree { get; set; }

        public virtual tblInstituteType tblInstituteType { get; set; }

        public virtual tblPerson tblPerson { get; set; }

        public override string ToString()
        {
            return $"{Field} - {Institute} ";
        }
    }
}
