using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCents.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Data { get; set; }
    }
}
