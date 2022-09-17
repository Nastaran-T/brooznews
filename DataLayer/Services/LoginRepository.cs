using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        private NewsContext db;
        public LoginRepository(NewsContext context)
        {
            db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.Logins.Any(x=>x.UserName==username && x.Password==password);
        }
    }
}
