using Model.EF;
using Model.ViewModel;
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

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return db.Products.OrderBy(u => u.CreatedDate).ToPagedList(page, pageSize);
        }

        public List<Product> ListNewProduct(int Top)
        {
            return db.Products
                .OrderByDescending(u => u.CreatedDate)
                .Take(Top)
                .ToList();
        }

        /// <summary>
        /// List product By CategoryId 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ProductViewModel> ListByCategoryId(long categoryId, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products
                .Where(u => u.CategoryID == categoryId)
                .Count();

            var model = db.Products
                .Where(u => u.CategoryID == categoryId)
                .OrderByDescending(u => u.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            //join 2 tables then add content into productviewmodel
            var models = (
                from a in db.Products
                join b in db.ProductCategories
                on a.CategoryID equals b.ID
                where a.CategoryID == categoryId
                select new ProductViewModel()
                {
                    ID = a.ID,
                    Name = a.Name,
                    MetaTitle = a.MetaTitle,
                    Price = a.Price,
                    Image = a.Image,
                    CateName = b.Name,
                    CateMetaTitle = b.MetaTitle,
                    CreatedDate = a.CreatedDate
                })   
                .OrderBy(u => u.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            //model.OrderBy(u => u.CreatedDate)
            //     .Skip((pageIndex - 1) * pageSize)
            //     .Take(pageSize);

            return models.ToList();
        }

        /// <summary>
        /// List featured Product
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        public List<Product> ListFeaturedProduct(int Top)
        {
            return db.Products
                .Where(u => u.TopHot != null && u.TopHot > DateTime.Now)
                .OrderByDescending(u => u.CreatedDate)
                .Take(Top)
                .ToList();
        }

        public List<Product> ListRelatedProduct(long ProductId)
        {
            var product = db.Products.Find(ProductId);
            return db.Products
                .Where(u => u.ID != ProductId && u.CategoryID == product.CategoryID)
                .ToList();
        }

        public List<Product> ListRelatedProductLimit(long ProductId, int Top)
        {
            var product = db.Products.Find(ProductId);
            return db.Products
                .Where(u => u.ID != ProductId && u.CategoryID == product.CategoryID)
                .OrderByDescending(u => u.CreatedDate)
                .Take(Top)
                .ToList();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);

                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.IncludeVAT = entity.IncludeVAT;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.Status = entity.Status;

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
                var product = db.Products.Find(ID);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            Product product = db.Products.Find(id);
            //switch Product status
            product.Status = !product.Status;
            db.SaveChanges();

            return product.Status;
        }

        public bool ChangeVAT(long id)
        {
            Product product = db.Products.Find(id);
            //switch Product VAT
            product.IncludeVAT = !product.IncludeVAT;
            db.SaveChanges();

            return product.IncludeVAT;
        }

    }
}
