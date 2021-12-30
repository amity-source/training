using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        public void Base() { }

        OnlineShopDbContext db = null;

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public int Login(string userName, string passWord)
        {
            //get matching name By Linq
            var result = db.Users.SingleOrDefault(u => u.UserName == userName);

            if (result == null)
            {
                //when no account found
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    //when account.status is Inactive(bit = 0)
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        //when input password not match
                        return -2;
                    }
                }
            }
        }

        //crud
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
        public void Update() { }
        public void Delete() { }
    }
}
