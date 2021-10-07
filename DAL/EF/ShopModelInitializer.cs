using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ShopModelInitializer : CreateDatabaseIfNotExists<ShopModel>
    {
        protected override void Seed(ShopModel context)
        {

            Role adminRole = context.Roles.Add(new Role { Name = "Admin"});
            Role user = context.Roles.Add(new Role { Name = "User"});
            context.SaveChanges();
            User adminUser = context.Users.Add(new User { Login = "admin", Password="admin2281337", Role = adminRole});
            User simpleUser = context.Users.Add(new User { Login = "s1mple", Password="sosikapapirimskogo2009", Role = adminRole});
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
