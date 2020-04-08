using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolOperationsApi.Models
{
    public class UserDetail
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public List<string> RoleNames { get; set; }
    }
}