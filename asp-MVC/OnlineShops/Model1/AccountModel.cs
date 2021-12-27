using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1
{
    public class AccountModel
    {
        //resharper edit
        private Framework.OnlineShopDbContext context = null;  

        public AccountModel()
        {
            context = new Framework.OnlineShopDbContext();
        }

        public bool Login(string userName, string password)
        {
            object[] sqlParameters =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password)
            };

            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password",sqlParameters).SingleOrDefault(); 

            return res;
        }


    } 
}
