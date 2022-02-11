using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        OnlineShopDbContext db = null;

        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }

        public Contact GetByID(long ID)
        {
            return db.Contacts.Single(u => u.Status == true || u.ID == ID);
        }

        public Contact GetActiveContact()
        {
            return db.Contacts.Single(u => u.Status == true);
        }
        public int InsertFeedBack(FeedBack entity)
        {
            db.FeedBacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
    }
}
