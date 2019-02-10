using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoCents.Data.Entities;

namespace TwoCents.API.Models
{
    public class CreatePetitionModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public PetitionCategory Category { get; set; }
    }
}
