using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineFoodApp.Models
{
    public class User
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public DateTime modifiedAt { get; set; }
        public string modifiedBy { get; set; }
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public bool isDeleted { get; set; }
        public string username { get; set; }

        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
    }
}
