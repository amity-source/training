using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;

        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public Product GetbyID(long id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return db.Products.OrderBy(u => u.CreatedDate).ToPagedList(page, pageSize);
        }

        public List<Product> ListNewProduct(int Top)
        {
            return db.Products.OrderByDescending(u => u.CreatedDate).Take(Top).ToList();
        }

        public List<Product> ListFeaturedProduct(int Top)
        {
            return db.Products.Where(u => u.TopHot != null && u.TopHot > DateTime.Now).OrderByDescending(u => u.CreatedDate).Take(Top).ToList();
        }

        public List<Product> ListRelatedProduct(long ProductId)
        {
            var product = db.Products.Find(ProductId);
            return db.Products.Where(u => u.ID != ProductId &&
                                     u.CategoryID == product.CategoryID).ToList();
        }

        public List<Product> ListRelatedProductLimit(long ProductId, int Top)
        {
            var product = db.Products.Find(ProductId);
            return db.Products.Where(u => u.ID != ProductId && u.CategoryID == product.CategoryID)
                                     .OrderByDescending(u => u.CreatedDate).Take(Top).ToList();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }
    }
}
