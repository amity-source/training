using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

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

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderBy(u => u.UserName).ToPagedList(page , pageSize);
        }  

        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
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


        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifedBy = entity.ModifedBy;
                user.ModifedDate = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public bool Delete(int ID)
        {
            try
            {
                var user = db.Users.Find(ID);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
