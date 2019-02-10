using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCents.Data.Entities
{
    public class PetitionEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public PetitionCategory Category { get; set; }

        public GovStatus Status { get; set; }

        #region -- Relationships --

        public IEnumerable<PetitionCommentEntity> PetitionCommentEntities { get; set; }

        #endregion
    }

    public enum GovStatus
    {
        UNNOTICED,
        WATCHING,
        UNDER_CONSIDERATION,
        APPROVED,
        DENIED
    }

    public enum PetitionCategory
    {
        TRAFFIC,
        SCHOOL_SAFETY,
        EDUCATION,
        LAWS_AND_REGULATIONS,
        OUTREACH,
        WILDLIFE
    }
}
