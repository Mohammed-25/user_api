using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public int age { get; set; }
        public int PohneNumber { set; get; }
        public int UserId { get; set; }
        public Users? User { get; set; }
    }
}