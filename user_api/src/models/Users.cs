using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Models
{
    public class Users
    {
        public Guid userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string adreess { get; set; } = string.Empty;
         public Profile? Profile { get; set; }
    }
}