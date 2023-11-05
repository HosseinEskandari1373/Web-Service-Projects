namespace FormModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FrmDbContext : DbContext
    {
        public FrmDbContext()
            : base("name=FrmDbContext")
        {
        }

        public virtual DbSet<tblConnectionLink> tblConnectionLinks { get; set; }
        public virtual DbSet<tblEducationDegree> tblEducationDegrees { get; set; }
        public virtual DbSet<tblEducationInfo> tblEducationInfoes { get; set; }
        public virtual DbSet<tblForeignLanguage> tblForeignLanguages { get; set; }
        public virtual DbSet<tblGender> tblGenders { get; set; }
        public virtual DbSet<tblInstituteType> tblInstituteTypes { get; set; }
        public virtual DbSet<tblJobOpportunity> tblJobOpportunities { get; set; }
        public virtual DbSet<tblLanguageInfo> tblLanguageInfoes { get; set; }
        public virtual DbSet<tblMaritalStatu> tblMaritalStatus { get; set; }
        public virtual DbSet<tblMilitaryStatu> tblMilitaryStatus { get; set; }
        public virtual DbSet<tblPerson> tblPersons { get; set; }
        public virtual DbSet<tblProvince> tblProvinces { get; set; }
        public virtual DbSet<tblSkillLevel> tblSkillLevels { get; set; }
        public virtual DbSet<tblWorkInfo> tblWorkInfoes { get; set; }
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblPersonAttachment> tblPersonAttachments { get; set; }
        public virtual DbSet<tblPersonImage> tblPersonImages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblConnectionLink>()
                .HasMany(e => e.tblPersons)
                .WithRequired(e => e.tblConnectionLink)
                .HasForeignKey(e => e.ConnectionLinkId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEducationDegree>()
                .Property(e => e.EnName)
                .IsUnicode(false);

            modelBuilder.Entity<tblEducationDegree>()
                .HasMany(e => e.tblEducationInfoes)
                .WithRequired(e => e.tblEducationDegree)
                .HasForeignKey(e => e.EducationDegreeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblForeignLanguage>()
                .Property(e => e.EnName)
                .IsUnicode(false);

            modelBuilder.Entity<tblForeignLanguage>()
                .HasMany(e => e.tblLanguageInfoes)
                .WithRequired(e => e.tblForeignLanguage)
                .HasForeignKey(e => e.ForeignLanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblGender>()
                .Property(e => e.EnName)
                .IsUnicode(false);

            modelBuilder.Entity<tblGender>()
                .HasMany(e => e.tblPersons)
                .WithRequired(e => e.tblGender)
                .HasForeignKey(e => e.GenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblInstituteType>()
                .HasMany(e => e.tblEducationInfoes)
                .WithOptional(e => e.tblInstituteType)
                .HasForeignKey(e => e.InstituteTypeId);

            modelBuilder.Entity<tblJobOpportunity>()
                .Property(e => e.ExpireDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblJobOpportunity>()
                .HasMany(e => e.tblPersons)
                .WithMany(e => e.tblJobOpportunities)
                .Map(m => m.ToTable("tblPersonJobOpportunity").MapLeftKey("JobOpportunityId").MapRightKey("PersonId"));

            modelBuilder.Entity<tblMaritalStatu>()
                .Property(e => e.EnName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMaritalStatu>()
                .HasMany(e => e.tblPersons)
                .WithRequired(e => e.tblMaritalStatu)
                .HasForeignKey(e => e.MaritalStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblMilitaryStatu>()
                .Property(e => e.EnName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMilitaryStatu>()
                .HasMany(e => e.tblPersons)
                .WithOptional(e => e.tblMilitaryStatu)
                .HasForeignKey(e => e.MilitaryStatusId);

            modelBuilder.Entity<tblPerson>()
                .Property(e => e.BirthDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblPerson>()
                .HasMany(e => e.tblEducationInfoes)
                .WithRequired(e => e.tblPerson)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<tblPerson>()
                .HasMany(e => e.tblLanguageInfoes)
                .WithRequired(e => e.tblPerson)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<tblPerson>()
            .HasMany(e => e.tblPersonImages)
            .WithRequired(e => e.tblPerson)
            .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<tblPerson>()
                .HasMany(e => e.tblPersonAttachments)
                .WithRequired(e => e.tblPerson)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<tblPerson>()
                .HasMany(e => e.tblWorkInfoes)
                .WithRequired(e => e.tblPerson)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<tblProvince>()
                .HasMany(e => e.tblCities)
                .WithRequired(e => e.tblProvince)
                .HasForeignKey(e => e.ProvinceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblWorkInfo>()
                .Property(e => e.StartDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblWorkInfo>()
                .Property(e => e.EndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonAttachment>()
                .Property(e => e.FileType)
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonImage>()
                .Property(e => e.FileType)
                .IsUnicode(false);
        }
    }
}
