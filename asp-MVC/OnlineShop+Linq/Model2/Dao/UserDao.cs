using Model2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2.Dao
{
    class UserDao
    {
        public void Base() {}

        OnlineShopDbContext2 db = null;

        public UserDao()
        {
            db = new OnlineShopDbContext2();
        }

        public bool Login(string userName, string passWord)
        {
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
        public void Update() {}
        public void Delete() {}
    }
}
