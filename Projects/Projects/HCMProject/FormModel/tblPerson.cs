
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text;

    [Table("tblPerson")]
    public partial class tblPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPerson()
        {
            tblEducationInfoes = new HashSet<tblEducationInfo>();
            tblLanguageInfoes = new HashSet<tblLanguageInfo>();
            tblPersonAttachments = new HashSet<tblPersonAttachment>();
            tblWorkInfoes = new HashSet<tblWorkInfo>();
            tblJobOpportunities = new HashSet<tblJobOpportunity>();
        }


        public string LanguageDesc
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (tblLanguageInfo li in tblLanguageInfoes)
                {
                    sb.AppendLine(li.ToString());
                }
                return sb.ToString();
            }
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(50)]
        public string CertificateNo { get; set; }

        public long NationalId { get; set; }

        [Required]
        [StringLength(8)]
        public string BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string BirthPlace { get; set; }

        [Required]
        [StringLength(50)]
        public string CertificatePlace { get; set; }

        [Required]
        [StringLength(50)]
        public string Religion { get; set; }

        [Required]
        [StringLength(50)]
        public string SubReligion { get; set; }

        [Required]
        [StringLength(50)]
        public string Nationality { get; set; }

        public byte GenderId { get; set; }
        public tblGender Gender
        {
            get
            {
                return Common.frmDb.tblGenders.Where(x => x.Id == GenderId).FirstOrDefault();
            }

        }

        public byte? MilitaryStatusId { get; set; }

        public tblMilitaryStatu MilitaryStatus
        {
            get
            {
                return Common.frmDb.tblMilitaryStatus.Where(x => x.Id == MilitaryStatusId).FirstOrDefault();
            }
        }

        public byte MaritalStatusId { get; set; }
        public tblMaritalStatu MaritalStatus
        {
            get
            {
                return Common.frmDb.tblMaritalStatus.Where(x => x.Id == MaritalStatusId).FirstOrDefault();
            }
        }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string SuggestedJob { get; set; }

        public int ExpectedSalary { get; set; }

        public byte ConnectionLinkId { get; set; }

        [Required]
        [StringLength(50)]
        public string RecommenderFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string RecommenderLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string RecommenderRelationship { get; set; }

        [Required]
        [StringLength(50)]
        public string RecommenderJob { get; set; }

        [Required]
        [StringLength(50)]
        public string RecommenderPhone { get; set; }

        [Required]
        [StringLength(500)]
        public string RecommenderAddress { get; set; }
   
        [Required]
        [StringLength(250)]
        public string Skill { get; set; }

        [Required]
        [StringLength(250)]
        public string ComputerInfo { get; set; }

        [Required]
        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public virtual tblConnectionLink tblConnectionLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEducationInfo> tblEducationInfoes { get; set; }

        public virtual tblGender tblGender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLanguageInfo> tblLanguageInfoes { get; set; }

        public virtual tblMaritalStatu tblMaritalStatu { get; set; }

        public virtual tblMilitaryStatu tblMilitaryStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonAttachment> tblPersonAttachments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonImage> tblPersonImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWorkInfo> tblWorkInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblJobOpportunity> tblJobOpportunities { get; set; }
    }
}
