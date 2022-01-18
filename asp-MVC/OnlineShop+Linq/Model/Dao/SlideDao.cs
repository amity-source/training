using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        OnlineShopDbContext db = null;

        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(u => u.Status == true).OrderBy(u => u.DisplayOrder).ToList();
        }

        public IEnumerable<Slide> ListAllPaging(int page, int pageSize)
        {
            return db.Slides.OrderBy(u => u.DisplayOrder).ToPagedList(page, pageSize);
        }

        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
    }
}
