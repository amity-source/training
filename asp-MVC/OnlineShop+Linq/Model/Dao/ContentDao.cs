using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;

        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public Content GetbyID(long id)
        {
            return db.Contents.Find(id);
        }

        public IEnumerable<Content> ListAllPaging(int page, int pageSize)
        {
            return db.Contents.OrderBy(u => u.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
    }
}
