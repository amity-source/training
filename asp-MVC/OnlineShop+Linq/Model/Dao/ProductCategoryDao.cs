using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;

        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> ListAllPaging(int page, int pageSize)
        {
            return db.ProductCategories.OrderBy(u => u.CreatedDate).ToPagedList(page, pageSize);
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(u => u.Status == true).OrderBy(u => u.DisplayOrder).ToList();
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
    }
}
