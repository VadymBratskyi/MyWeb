using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace userAuthorize.Models
{
    public class UserContext: DbContext
    {
        public UserContext()
            :base("AccountConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}