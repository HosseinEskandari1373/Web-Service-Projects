namespace FormModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tblLanguageInfo")]
    public partial class tblLanguageInfo
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public byte ForeignLanguageId { get; set; }

        public tblForeignLanguage ForeignLanguage
        {
            get
            {
                return Common.frmDb.tblForeignLanguages.Where(x => x.Id == ForeignLanguageId).FirstOrDefault();
            }
        }
        public byte ReadingSkillLevelId { get; set; }
        public tblSkillLevel ReadingSkill { get
            {
                return Common.frmDb.tblSkillLevels.Where(x => x.Id == ReadingSkillLevelId).FirstOrDefault();
            }
        }

        public byte WritingSkillLevelId { get; set; }
        public tblSkillLevel WritingSkill
        { get
            {
                return Common.frmDb.tblSkillLevels.Where(x => x.Id == WritingSkillLevelId).FirstOrDefault();
            }
        }

        public byte SpeakingSkillLevelId { get; set; }
        public tblSkillLevel SpeakingSkill
        {
            get
            {
                return Common.frmDb.tblSkillLevels.Where(x => x.Id == SpeakingSkillLevelId).FirstOrDefault();
            }
        }

        public virtual tblForeignLanguage tblForeignLanguage { get; set; }

        public virtual tblPerson tblPerson { get; set; }
        public override string ToString()
        {
            return $"::{ForeignLanguage}:: خواندن:{ReadingSkill.Name}-نوشتن:{WritingSkill.Name}-مکالمه:{SpeakingSkill.Name}";
        }
    }
}
