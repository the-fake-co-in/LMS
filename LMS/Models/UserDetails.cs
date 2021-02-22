using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class UserDetails
    {
        public UserMaster userMaster { get; set; }
        
        public UserInfo userInfo { get; set; }
    }
}