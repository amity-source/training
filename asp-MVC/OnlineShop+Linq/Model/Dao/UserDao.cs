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

        public bool Login(string userName,string passWord)
        {
            //get matching name + password By Linq
            var result = db.Users.Count(u =>
            u.UserName == userName && u.Password == passWord);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
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
