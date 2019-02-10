using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoCents.API.Models
{
    public class AddCommentModel
    {
        public string Username { get; set; }

        public string Comment { get; set; }
    }
}
