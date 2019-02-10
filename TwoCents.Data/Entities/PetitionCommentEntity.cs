using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCents.Data.Entities
{
    public class PetitionCommentEntity
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public DateTime TimeStamp { get; set; }

        #region -- Relationships --

        public Guid PetitionEntityId { get; set; }

        public PetitionEntity PetitionEntity { get; set; }

        #endregion
    }
}
