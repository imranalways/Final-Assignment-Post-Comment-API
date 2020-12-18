using Post_Comment_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Post_Comment_API.Repositories
{
    public class LoginRepository : Repository<Login>
    {
        public List<Login> Login(int username, string password)
        {
            return GetAll().Where(x => x.Lid == username && x.Password==password).ToList();
        }
    }
}