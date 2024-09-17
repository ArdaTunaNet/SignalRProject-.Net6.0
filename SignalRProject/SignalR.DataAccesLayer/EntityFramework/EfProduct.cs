using Microsoft.EntityFrameworkCore;
using SignalR.DataAccesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DataAccesLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.EntityFramework
{
    public class EfProduct : GenericRepository<Product>, IProduct
    {
        public EfProduct(SignalRContext context) : base(context)
        {
        }

        public int GetProductCount()
        {
           using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int GetProductCountCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=>z.CategoryID).FirstOrDefault())).Count();
        }

        public int GetProductCountCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();
            return values;
        }
    }
}
